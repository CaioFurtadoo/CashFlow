using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;

namespace CashFlow.Application.UseCases.Expenses.GetAll
{
    public class GetAllExpenseUseCase : IGetAllExpenseUseCase
    {
        private readonly IExpenseReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;
        public GetAllExpenseUseCase(IExpenseReadOnlyRepository repository, IMapper mapper, ILoggedUser logged)
        {
            _repository = repository;
            _mapper = mapper;
            _loggedUser = logged;
        }

        public async Task<ResponseExpensesJson> Execute()
        {
            var loggedUser = await _loggedUser.Get();

            var result = await _repository.GetAll(loggedUser);
            return new ResponseExpensesJson
            {
                Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
            };
        }
    }
}
