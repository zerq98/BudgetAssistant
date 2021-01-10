using BudgetAssistant.Application.Dto.Category;
using BudgetAssistant.Application.Interface;
using BudgetAssistant.Web.Models;
using BudgetAssistant.Web.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BudgetAssistant.Web.Controllers
{
    [Authorize]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly ICategoryService _categoryService;

        public ExpenseController(IExpenseService expenseService,
                                 ICategoryService categoryService)
        {
            _expenseService = expenseService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(string userId)
        {
            ExpensesAndCategoryVm viewModel = new ExpensesAndCategoryVm();
            viewModel.Categories = await _categoryService.GetCategories(userId);
            foreach(var category in viewModel.Categories)
            {
                category.Expenses = await _expenseService.GetAllFromCategory(category.Id);
            }
            ViewBag.userId = userId;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(ExpensesAndCategoryVm model)
        {
            if(new CategoryValidation().Validate(model.CreateCategory).IsValid)
            {
                await _categoryService.AddNewCategory(model.CreateCategory);
            }

            return RedirectToAction("Index", new { userId = model.CreateCategory.ApplicationUserId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExpense(ExpensesAndCategoryVm model)
        {
            if(new ExpenseValidation().Validate(model.CreateExpense).IsValid)
            {
                await _expenseService.AddExpense(model.CreateExpense);
            }

            return RedirectToAction("Index",new { userId = model.CreateExpense.ApplicationUserId });
        }
    }
}
