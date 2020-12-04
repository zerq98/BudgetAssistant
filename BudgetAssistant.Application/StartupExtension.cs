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
        }
    }
}