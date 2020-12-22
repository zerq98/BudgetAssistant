using AutoMapper;
using BudgetAssistant.Application.Dto.Category;
using BudgetAssistant.Application.Dto.Expense;
using BudgetAssistant.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Expense, ViewExpenseDto>();
            CreateMap<ExpenseCategory, ViewCategoryDto>();
            CreateMap<ExpenseCategory, ViewCategoryTabDto>();
            CreateMap<CreateCategoryDto, ExpenseCategory>();
            CreateMap<CreateExpenseDto, Expense>();
            CreateMap<EditCategoryDto, ExpenseCategory>();
        }
    }
}
