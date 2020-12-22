using System;

namespace BudgetAssistant.Domain.Entity
{
    public class Expense
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ExpenseDate { get; set; }

        public double Value { get; set; }

        public int CategoryId { get; set; }

        public ExpenseCategory ItemCategory { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}