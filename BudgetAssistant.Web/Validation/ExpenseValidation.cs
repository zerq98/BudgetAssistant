using BudgetAssistant.Application.Dto.Expense;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetAssistant.Web.Validation
{
    public class ExpenseValidation : AbstractValidator<CreateExpenseDto>
    {
        public ExpenseValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Value).NotEmpty().NotNull();
            RuleFor(x => x.CategoryId).NotEmpty().NotNull();
            RuleFor(x => x.ApplicationUserId).NotEmpty().NotNull();
        }
    }
}
