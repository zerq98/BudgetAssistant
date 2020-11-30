using BudgetAssistant.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAssistant.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<string> RegisterAsync(ApplicationUser user,string password);

        public Task<string> EditUserAsync(ApplicationUser user);

        public IQueryable<ApplicationUser> GetUsers();

        public Task<ApplicationUser> GetUserByIdAsync(string userId);

        public Task AssignUserToRoleAsync(string userId, List<string> roles);

        public Task<List<string>> GetUserRoles(string userId);

        public Task<ApplicationUser> GetUserByEmailAsync(string email);

        public Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    }
}
