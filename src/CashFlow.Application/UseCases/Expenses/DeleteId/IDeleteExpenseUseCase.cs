namespace CashFlow.Application.UseCases.Expenses.DeleteId
{
    public interface IDeleteExpenseUseCase
    {
        Task Execute(long id);
    }
}
