using BudgetAssistant.Application.Dto.Category;
using FluentValidation;

namespace BudgetAssistant.Web.Validation
{
    public class CategoryValidation : AbstractValidator<CreateCategoryDto>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Matches("^[a-zA-Z]{4,}$");
            RuleFor(x => x.ApplicationUserId).NotEmpty().NotNull();
        }
    }
}
