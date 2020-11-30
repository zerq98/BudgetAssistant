using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Domain.Entity
{
    public class Jar : BaseEntity
    {
        public string Name { get; set; }

        public int Percentage { get; set; }

        public double MoneyLeft { get; set; }

        public List<ExpenseCategory> Categories { get; set; }
    }
}
