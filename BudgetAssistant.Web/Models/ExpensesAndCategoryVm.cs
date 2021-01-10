using BudgetAssistant.Application.Dto.Category;
using BudgetAssistant.Application.Dto.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetAssistant.Web.Models
{
    public class ExpensesAndCategoryVm
    {
        public List<ViewCategoryTabDto> Categories { get; set; }
        public CreateCategoryDto CreateCategory { get; set; }
        public CreateExpenseDto CreateExpense { get; set; }
    }
}
