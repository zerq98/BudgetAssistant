using BudgetAssistant.Application.Dto.Category;
using BudgetAssistant.Application.Dto.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetAssistant.Web.Models
{
    public class HomeVM
    {
        public List<ViewCategoryDto> Categories { get; set; }
        public List<ViewExpenseDto> LastOperations { get; set; }
    }
}
