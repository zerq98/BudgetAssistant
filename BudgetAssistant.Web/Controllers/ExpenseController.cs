using BudgetAssistant.Application.Dto.Category;
using BudgetAssistant.Application.Interface;
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
            var list = await _categoryService.GetCategories(userId);
            ViewBag.userId = userId;
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDto dto)
        {
            if(new CategoryValidation().Validate(dto).IsValid)
            {
                await _categoryService.AddNewCategory(dto);
            }

            return RedirectToAction("Index");
        }
    }
}
