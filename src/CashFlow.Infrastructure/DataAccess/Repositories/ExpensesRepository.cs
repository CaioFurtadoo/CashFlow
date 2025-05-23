﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpenseReadOnlyRepository, IExpenseWriteOnlyRepository, IExpenseDeleteOnlyRepository, IExpenseUpdateOnlyRepository
    {
        private readonly CashFlowDbContext _dbcontext;

        public ExpensesRepository(CashFlowDbContext context)
        {
            _dbcontext = context;
        }

        public async Task Add(Expense expense)
        {
            await _dbcontext.AddAsync(expense);
        }

        public async Task<List<Expense>> GetAll(User user)
        {
            return await _dbcontext.Expenses.AsNoTracking().Where(e => e.UserId == user.Id).ToListAsync();
        }

        async Task<Expense?> IExpenseReadOnlyRepository.GetId(User user,long id)
        {
            return await _dbcontext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && e.UserId == user.Id);
        }
        async Task<Expense?> IExpenseUpdateOnlyRepository.GetId(User user, long id)
        {
            return await _dbcontext.Expenses.FirstOrDefaultAsync(e => e.Id == id && e.UserId == user.Id);
        }

        public async Task<bool> DeleteId(User user, long id)
        {
            var result =  await _dbcontext.Expenses.FirstOrDefaultAsync(e => e.Id == id && e.UserId == user.Id);
            if(result is null)
            {
                return false;
            }
            _dbcontext.Expenses.Remove(result);
            return true;
        }

        public void Update(Expense expense)
        {
            _dbcontext.Expenses.Update(expense);
        }

        public async Task<List<Expense>> FilterByMonth(User user, DateOnly date)
        {
            var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

            var daysInMonth = DateTime.DaysInMonth(year: date.Year, date.Month);
            var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

            return await _dbcontext.Expenses
                .AsNoTracking()
                .Where(expense => expense.Date >= startDate && expense.Date <= endDate && expense.UserId == user.Id)
                .OrderBy(expense => expense.Date)
                .ThenBy(expense => expense.Title)
                .ToListAsync();
        }
    }
}
