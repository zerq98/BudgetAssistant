using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Domain.Entity
{
    public class Expense : BaseEntity
    {
        public string Name { get; set; }

        public int JarId { get; set; }

        public Jar Jar { get; set; }

        public DateTime ExpenseDate { get; set; }

        public int CategoryId { get; set; }

        public ExpenseCategory ItemCategory { get; set; }
    }
}
