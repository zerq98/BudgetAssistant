using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetAssistant.Application.Dto.Category;
using BudgetAssistant.Application.Interface;
using BudgetAssistant.Domain.Entity;
using BudgetAssistant.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetAssistant.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IExpenseCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;
        private readonly IUserRepository _userRepository;

        public CategoryService(IExpenseCategoryRepository categoryRepository,
                               IMapper mapper, ILogger<CategoryService> logger,
                               IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;
        }
        public async Task AddNewCategory(CreateCategoryDto dto)
        {
            try
            {
                var model = _mapper.Map<ExpenseCategory>(dto);
                model.Expenses = new List<Expense>();
                model.CreationDate = DateTime.Now;
                model.LastModified = model.CreationDate;
                model.ApplicationUser = await _userRepository.GetUserByIdAsync(model.ApplicationUserId);
                await _categoryRepository.AddNewAsync(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public Task EditCategory(EditCategoryDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ViewCategoryTabDto>> GetCategories(string userId)
        {
            var categories = await _categoryRepository
                .GetAll(userId)
                .ProjectTo<ViewCategoryTabDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return categories;
        }

        public async Task<List<ViewCategoryDto>> GetViewCategoriesAsync(string userId)
        {
            return await _categoryRepository
                .GetAll(userId)
                .ProjectTo<ViewCategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public Task RemoveCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
