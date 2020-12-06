using BudgetAssistant.Application.Interface;
using BudgetAssistant.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BudgetAssistant.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AuthenticationVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _accountService.Register(model.Register);

                    return RedirectToAction("Success");
                }
                catch
                {
                    return View("Error");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthenticationVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _accountService.Login(model.Login);

                    if (result == "Wrong Data")
                    {
                        return View();
                    }

                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    return View("Error");
                }
            }
            else
            {
                return View();
            }
        }
    }
}