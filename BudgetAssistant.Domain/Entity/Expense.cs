using System;

namespace BudgetAssistant.Domain.Entity
{
    public class Expense : BaseEntity
    {
        public string Name { get; set; }

        public DateTime ExpenseDate { get; set; }

        public int CategoryId { get; set; }

        public ExpenseCategory ItemCategory { get; set; }
    }
}