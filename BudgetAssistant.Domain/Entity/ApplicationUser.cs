using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Domain.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public List<Jar> Jars { get; set; }

        public int BudgetId { get; set; }

        public Budget Budget { get; set; }

        public bool IsActive { get; set; }
    }
}
