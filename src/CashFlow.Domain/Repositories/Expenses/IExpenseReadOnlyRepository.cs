﻿using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpenseReadOnlyRepository
    {
        Task<List<Expense>> GetAll(Entities.User user);
        Task<Expense?> GetId(Entities.User user, long id);
        Task<List<Expense>> FilterByMonth(Entities.User user, DateOnly date); 
    }
}
