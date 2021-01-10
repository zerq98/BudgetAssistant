using BudgetAssistant.Domain.Entity;
using BudgetAssistant.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetAssistant.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDataContext _context;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public ExpenseRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(Expense model)
        {
            try
            {
                await _context.Expenses.AddAsync(model);
                var budget = await _context.Budgets.FirstOrDefaultAsync(x => x.ApplicationUserId == model.ApplicationUserId);
                budget.MonthSavings += model.Value;
                _context.Budgets.Update(budget);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch(DbException ex)
            {
                _logger.Error(ex.Message);
                return 0;
            }
        }

        public async Task<int> EditAsync(Expense model)
        {
            try
            {
                _context.Expenses.Update(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (DbException ex)
            {
                _logger.Error(ex.Message);
                return 0;
            }
        }

        public IQueryable<Expense> GetAll(string userId)
        {
            if (userId != null)
            {
                return _context.Expenses.Where(x => x.ApplicationUserId == userId);
            }
            return _context.Expenses;
        }

        public IQueryable<Expense> GetAllFromCategory(int categoryId)
        {
            return _context.Expenses.Where(x => x.CategoryId == categoryId && x.ExpenseDate>=DateTime.Now.AddDays(-30));
        }

        public async Task<Expense> GetByIdAsync(int modelId)
        {
            return await _context.Expenses.FirstOrDefaultAsync(x => x.Id == modelId);
        }

        public async Task RemoveAsync(Expense model)
        {
            try
            {
                _context.Expenses.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}