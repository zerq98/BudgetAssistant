using System.Collections.Generic;

namespace BudgetAssistant.Domain.Entity
{
    public class ExpenseCategory : BaseEntity
    {
        public string Name { get; set; }

        public double TotalExpensesValue { get; set; }

        public List<Expense> Expenses { get; set; }
    }
}