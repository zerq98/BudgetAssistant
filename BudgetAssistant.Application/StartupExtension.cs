using AutoMapper;
using BudgetAssistant.Application.Interface;
using BudgetAssistant.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetAssistant.Application
{
    public static class StartupExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(Application.StartupExtension));
        }
    }
}