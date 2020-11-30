using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Domain.Entity
{
    public class Budget : BaseEntity
    {
        public double Income { get; set; }

        public double Savings { get; set; }

        public bool RegularIncome { get; set; }

        public TimeSpan IncomeInterval { get; set; }
    }
}
