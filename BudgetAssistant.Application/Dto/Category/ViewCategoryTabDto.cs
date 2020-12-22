using BudgetAssistant.Application.Dto.Expense;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Application.Dto.Category
{
    public class ViewCategoryTabDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ViewExpenseDto> Expenses { get; set; }
    }
}
