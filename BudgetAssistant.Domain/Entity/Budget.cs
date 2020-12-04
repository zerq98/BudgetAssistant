using System;

namespace BudgetAssistant.Domain.Entity
{
    public class Budget : BaseEntity
    {
        public double Income { get; set; }

        public double TotalSavings { get; set; }

        public double MonthSavings { get; set; }

        public bool RegularIncome { get; set; }

        public TimeSpan IncomeInterval { get; set; }
    }
}