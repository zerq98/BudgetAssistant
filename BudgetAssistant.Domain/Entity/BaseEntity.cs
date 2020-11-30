using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Domain.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
