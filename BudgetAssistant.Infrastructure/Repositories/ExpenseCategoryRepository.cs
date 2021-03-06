﻿using BudgetAssistant.Domain.Entity;
using BudgetAssistant.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetAssistant.Infrastructure.Repositories
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly AppDataContext _context;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public ExpenseCategoryRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(ExpenseCategory model)
        {
            try
            {
                await _context.ExpenseCategories.AddAsync(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch(DbException ex)
            {
                _logger.Error(ex.Message);
                return 0;
            }
        }

        public async Task<int> EditAsync(ExpenseCategory model)
        {
            try
            {
                _context.ExpenseCategories.Update(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (DbException ex)
            {
                _logger.Error(ex.Message);
                return 0;
            }
        }

        public IQueryable<ExpenseCategory> GetAll(string userId)
        {
            if (userId != null)
            {
                var categories = _context.ExpenseCategories.Where(x => x.ApplicationUserId == userId);
                return categories;
            }
            return _context.ExpenseCategories;
        }

        public async Task<ExpenseCategory> GetByIdAsync(int modelId)
        {
            return await _context.ExpenseCategories.FirstOrDefaultAsync(x => x.Id == modelId);
        }

        public async Task RemoveAsync(ExpenseCategory model)
        {
            try
            {
                _context.ExpenseCategories.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}