using BudgetAssistant.Domain.Entity;
using BudgetAssistant.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetAssistant.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDataContext _context;

        public UserRepository(UserManager<ApplicationUser> userManager,
                              AppDataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task AssignUserToRoleAsync(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                if (result.Succeeded)
                {
                    await _userManager.AddToRolesAsync(user, roles);
                }
            }
        }

        public async Task<string> EditUserAsync(ApplicationUser user)
        {
            try
            {
                await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
            catch
            {
                return "Error";
            }
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return _context.Users;
        }

        public async Task<string> RegisterAsync(ApplicationUser user, string password)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, password);
                await _context.SaveChangesAsync();
                return user.Id;
            }
            catch
            {
                return "Error";
            }
        }

        public async Task<List<string>> GetUserRoles(string userId)
        {
            return (await _userManager.GetRolesAsync(await GetUserByIdAsync(userId))).ToList();
        }

        public async Task<ApplicationUser> GetUserByLoginAsync(string login)
        {
            return await _userManager.FindByNameAsync(login);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task RemoveUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.IsActive = false;
            await _userManager.UpdateAsync(user);
        }
    }
}