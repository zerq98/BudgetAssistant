using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Application.Dto.Expense
{
    public class ViewExpenseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ExpenseDate { get; set; }

        public double Value { get; set; }
    }
}
