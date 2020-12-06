using BudgetAssistant.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace BudgetAssistant.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDataContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public RoleRepository(AppDataContext context,
                              RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task CreateRoleAsync(IdentityRole role)
        {
            try
            {
                await _roleManager.CreateAsync(role);
                await _context.SaveChangesAsync();
            }
            catch(DbException ex)
            {
                _logger.Error(ex.Message);
            }
        }

        public async Task EditRoleAsync(IdentityRole role)
        {
            try
            {
                _context.Roles.Update(role);
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                _logger.Error(ex.Message);
            }
        }

        public async Task<List<IdentityRole>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task RemoveRoleAsync(string roleId)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(roleId);

                if (role != null)
                {
                    await _roleManager.DeleteAsync(role);
                }
            }
            catch (DbException ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}