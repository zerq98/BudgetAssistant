using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetAssistant.Application.Dto.Expense;
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
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ExpenseService> _logger;

        public ExpenseService(IExpenseRepository expenseRepository,
                              IMapper mapper,
                              ILogger<ExpenseService> logger)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> AddExpense(CreateExpenseDto dto)
        {
            var expense = _mapper.Map<Expense>(dto);
            expense.ExpenseDate = DateTime.Now;
            try
            {
                await _expenseRepository.AddNewAsync(expense);
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<List<ViewExpenseDto>> GetAll(string userId)
        {
            return await _expenseRepository
                .GetAll(userId)
                .ProjectTo<ViewExpenseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<ViewExpenseDto>> GetAllFromCategory(int categoryId)
        {
            return await _expenseRepository
                .GetAllFromCategory(categoryId)
                .ProjectTo<ViewExpenseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> RemoveExpense(int id)
        {
            try
            {
                var expense = _mapper.Map<Expense>(await _expenseRepository.GetByIdAsync(id));
                if (expense != null)
                {
                    await _expenseRepository.RemoveAsync(expense);
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
