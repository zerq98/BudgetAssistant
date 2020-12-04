using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BudgetAssistant.Domain.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public List<ExpenseCategory> Categories { get; set; }

        public int BudgetId { get; set; }

        public Budget Budget { get; set; }

        public bool IsActive { get; set; }
    }
}