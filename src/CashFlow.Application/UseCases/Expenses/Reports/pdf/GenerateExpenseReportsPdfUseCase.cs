using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.Reports.pdf
{
    public class GenerateExpenseReportsPdfUseCase : IGenerateExpenseReportsPdfUseCase
    {
        private const string CURRENCY_SYMBOL = "$";
        private readonly IExpenseReadOnlyRepository _repository;

        public GenerateExpenseReportsPdfUseCase(IExpenseReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);
            if(expenses.Count == 0)
            {
                return [];
            }
            return [];
        }
    }
}
