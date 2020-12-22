using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Application.Dto.Expense
{
    public class CreateExpenseDto
    {
        public string Name { get; set; }

        public double Value { get; set; }

        public int CategoryId { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
