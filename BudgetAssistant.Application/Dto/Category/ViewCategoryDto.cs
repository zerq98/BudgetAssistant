using BudgetAssistant.Application.Dto.Expense;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Application.Dto.Category
{
    public class ViewCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double TotalExpensesValue { get; set; }

        public List<ViewExpenseDto> Expenses { get; set; }
    }
}
