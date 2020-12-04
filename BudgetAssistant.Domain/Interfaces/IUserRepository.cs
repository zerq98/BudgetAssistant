using BudgetAssistant.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetAssistant.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<string> RegisterAsync(ApplicationUser user, string password);

        public Task<string> EditUserAsync(ApplicationUser user);

        public IQueryable<ApplicationUser> GetUsers();

        public Task<ApplicationUser> GetUserByIdAsync(string userId);

        public Task AssignUserToRoleAsync(string userId, List<string> roles);

        public Task<List<string>> GetUserRoles(string userId);

        public Task<ApplicationUser> GetUserByLoginAsync(string login);

        public Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    }
}