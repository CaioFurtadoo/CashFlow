using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpenseUpdateOnlyRepository
    {
        Task<Expense?> GetId(Entities.User user , long id);
        void Update(Expense expense);
    }
}
