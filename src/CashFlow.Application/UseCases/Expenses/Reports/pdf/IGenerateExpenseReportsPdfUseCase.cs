namespace CashFlow.Application.UseCases.Expenses.Reports.pdf
{
    public interface IGenerateExpenseReportsPdfUseCase
    {
        public Task<byte[]> Execute(DateOnly month);
    }
}
