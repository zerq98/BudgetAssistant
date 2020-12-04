using BudgetAssistant.Application.Dto.Account;
using BudgetAssistant.Application.Interface;
using BudgetAssistant.Domain.Entity;
using BudgetAssistant.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BudgetAssistant.Application.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBudgetRepository _budgetRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(IUserRepository userRepository,
                              IBudgetRepository budgetRepository,
                              IRoleRepository roleRepository,
                              SignInManager<ApplicationUser> signInManager)
        {
            _userRepository = userRepository;
            _budgetRepository = budgetRepository;
            _roleRepository = roleRepository;
            _signInManager = signInManager;
        }

        public async Task<string> Login(LoginDto dto)
        {
            var user = await _userRepository.GetUserByLoginAsync(dto.Login);

            if (user != null)
            {
                if (await _userRepository.CheckPasswordAsync(user, dto.Password))
                {
                    var result = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberPassword, true);
                    if (result.Succeeded)
                    {
                        return "Logged";
                    }
                    else if (result.IsLockedOut)
                    {
                        return "Locked";
                    }
                }
            }

            throw new NotImplementedException();
        }

        public async Task<bool> Register(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                Email = dto.Email,
                UserName = dto.Login
            };

            var result = await _userRepository.RegisterAsync(user, dto.Password);

            if (result != "Error")
            {
                var budgetId = await _budgetRepository.AddNewAsync(new Budget
                {
                    ApplicationUserId = result,
                    RegularIncome = false,
                    MonthSavings = 0,
                    TotalSavings = 0,
                    Income = 0
                });

                user = await _userRepository.GetUserByIdAsync(result);
                user.BudgetId = budgetId;

                await _userRepository.EditUserAsync(user);

                return true;
            }

            return false;
        }
    }
}