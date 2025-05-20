using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;

namespace CashFlow.Application.UseCases.Expenses.Reports.pdf
{
    public class GenerateExpenseReportsPdfUseCase : IGenerateExpenseReportsPdfUseCase
    {
        private const string CURRENCY_SYMBOL = "$";
        private readonly IExpenseReadOnlyRepository _repository;
        private readonly ILoggedUser _loggedUser;

        public GenerateExpenseReportsPdfUseCase(IExpenseReadOnlyRepository repository, ILoggedUser logged)
        {
            _repository = repository;
            _loggedUser = logged;
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var loggedUser = await _loggedUser.Get();
            var expenses = await _repository.FilterByMonth(loggedUser, month);
            if(expenses.Count == 0)
            {
                return [];
            }
            return [];
        }
    }
}
