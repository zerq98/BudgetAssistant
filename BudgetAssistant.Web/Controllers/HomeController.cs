using BudgetAssistant.Application.Dto.Category;
using BudgetAssistant.Application.Dto.Expense;
using BudgetAssistant.Application.Interface;
using BudgetAssistant.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BudgetAssistant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExpenseService _expenseService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger,
            IExpenseService expenseService,ICategoryService categoryService)
        {
            _logger = logger;
            _expenseService = expenseService;
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> IndexAsync(string userId)
        {
            var model = new HomeVM();
            model.Categories = await _categoryService.GetViewCategoriesAsync(userId);
            model.LastOperations = new List<ViewExpenseDto>();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}