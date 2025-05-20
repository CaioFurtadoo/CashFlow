using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IUserReadOnlyRepository _readRepository;
        private readonly IAcessTokenGenerator _accessTokenGenerator;

        public DoLoginUseCase(IPasswordEncripter passwordEncripter, IUserReadOnlyRepository userReadOnly, IAcessTokenGenerator token)
        {
            _accessTokenGenerator = token;
            _passwordEncripter = passwordEncripter;
            _readRepository = userReadOnly;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestLoginJson request)
        {
            var user = await _readRepository.GetUserByEmail(request.Email);

            if(user == null)
            {
                throw new InvalidLoginException();
            }

            var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

            if(!passwordMatch)
            {
                throw new InvalidLoginException();
            }

            return new ResponseRegisterUserJson
            {
                Token = _accessTokenGenerator.Generate(user),
                Name = user.Name
            };
        }
    }
}
