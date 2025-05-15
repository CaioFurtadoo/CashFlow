namespace CashFlow.Application.UseCases.Expenses.Reports.Excel
{
    public interface IGenerateExpenseReportsExcelUseCase
    {
        public Task<byte[]> Execute(DateOnly month);
    }
}
