using BudgetAssistant.Domain.Entity;
using BudgetAssistant.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAssistant.Infrastructure.Repositories
{
    public class JarRepository : IJarRepository
    {
        private readonly AppDataContext _context;

        public JarRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(Jar model)
        {
            try
            {
                await _context.Jars.AddAsync(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> EditAsync(Jar model)
        {
            try
            {
                _context.Jars.Update(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch
            {
                return 0;
            }
        }

        public IQueryable<Jar> GetAll(string userId)
        {
            if (userId != null)
            {
                return _context.Jars.Where(x => x.ApplicationUserId == userId);
            }
            else
            {
                return _context.Jars;
            }
        }

        public async Task<Jar> GetByIdAsync(int modelId)
        {
            return await _context.Jars.FirstOrDefaultAsync(x => x.Id == modelId);
        }

        public async Task RemoveAsync(Jar model)
        {
            try
            {
                _context.Jars.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch
            {

            }
        }
    }
}
