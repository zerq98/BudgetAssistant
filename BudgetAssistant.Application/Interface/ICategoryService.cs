using BudgetAssistant.Application.Dto.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAssistant.Application.Interface
{
    public interface ICategoryService
    {
        Task AddNewCategory(CreateCategoryDto dto);

        Task<List<ViewCategoryTabDto>> GetCategories(string userId);

        Task<List<ViewCategoryDto>> GetViewCategoriesAsync(string userId);

        Task RemoveCategory(int categoryId);

        Task EditCategory(EditCategoryDto dto);
    }
}
