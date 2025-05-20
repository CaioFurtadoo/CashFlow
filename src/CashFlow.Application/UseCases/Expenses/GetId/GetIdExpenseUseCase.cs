using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.GetId
{
    public class GetIdExpenseUseCase : IGetIdExpenseUseCase
    {
        private readonly IMapper _mapper;
        private readonly IExpenseReadOnlyRepository _repository;
        private readonly ILoggedUser _loggedUser;

        public GetIdExpenseUseCase(IExpenseReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
        {
            _mapper = mapper;
            _repository = repository;
            _loggedUser = loggedUser;
        }

        public async Task<ResponseExpenseJson> Execute(long id)
        {
            var loggedUser = await _loggedUser.Get();
            var result = await _repository.GetId(loggedUser, id);

            if(result is null)
            {
                throw new NotFoundException(ResourceErrorMessage.EXPENSE_NOT_FOUND);
            }

            return _mapper.Map<ResponseExpenseJson>(result);
        }
    }
}
