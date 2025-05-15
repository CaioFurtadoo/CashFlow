namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpenseDeleteOnlyRepository
    {
        Task<bool> DeleteId(long id);
    }
}
