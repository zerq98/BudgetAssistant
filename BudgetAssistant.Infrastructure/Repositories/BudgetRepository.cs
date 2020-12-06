using BudgetAssistant.Domain.Entity;
using BudgetAssistant.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetAssistant.Infrastructure.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly AppDataContext _context;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public BudgetRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(Budget model)
        {
            try
            {
                await _context.Budgets.AddAsync(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch(DbException ex)
            {
                _logger.Error(ex.Message);
                return 0;
            }
        }

        public async Task<int> EditAsync(Budget model)
        {
            try
            {
                _context.Budgets.Update(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (DbException ex)
            {
                _logger.Error(ex.Message);
                return 0;
            }
        }

        public IQueryable<Budget> GetAll(string userId)
        {
            if (userId != null)
            {
                return _context.Budgets.Where(x => x.ApplicationUserId == userId);
            }
            return _context.Budgets;
        }

        public async Task<Budget> GetByIdAsync(int modelId)
        {
            return await _context.Budgets.FirstOrDefaultAsync(x => x.Id == modelId);
        }

        public async Task RemoveAsync(Budget model)
        {
            try
            {
                _context.Budgets.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}