using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAssistant.Domain.Interfaces
{
    public interface IRoleRepository
    {
        public Task<List<IdentityRole>> GetAllRolesAsync();

        public Task CreateRoleAsync(IdentityRole role);

        public Task RemoveRoleAsync(string roleId);

        public Task EditRoleAsync(IdentityRole role);
    }
}
