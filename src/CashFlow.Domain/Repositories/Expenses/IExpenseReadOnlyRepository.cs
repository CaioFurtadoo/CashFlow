using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpenseReadOnlyRepository
    {
        Task<List<Expense>> GetAll();
        Task<Expense?> GetId(long id);
        Task<List<Expense>> FilterByMonth(DateOnly date); 
    }
}
