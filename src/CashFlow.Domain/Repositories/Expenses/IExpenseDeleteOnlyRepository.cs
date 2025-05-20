namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpenseDeleteOnlyRepository
    {
        Task<bool> DeleteId(Entities.User user, long id);
    }
}
