using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Domain.Entity
{
    public class ExpenseCategory : BaseEntity
    {
        public string Name { get; set; }

        public int JarId { get; set; }

        public Jar Jar { get; set; }

        public bool CanRemove { get; set; }
    }
}
