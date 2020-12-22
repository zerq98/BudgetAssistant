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

        public CategoryService(IExpenseCategoryRepository categoryRepository,
                               IMapper mapper, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task AddNewCategory(CreateCategoryDto dto)
        {
            try
            {
                await _categoryRepository.AddNewAsync(_mapper.Map<ExpenseCategory>(dto));
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
            return await _categoryRepository
                .GetAll(userId)
                .ProjectTo<ViewCategoryTabDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public Task RemoveCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
