using BudgetAssistant.Domain.Entity;
using BudgetAssistant.Domain.Interfaces;
using BudgetAssistant.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BudgetAssistant.Infrastructure
{
    public static class StartupExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDataContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBudgetRepository, BudgetRepository>();
            services.AddTransient<IExpenseCategoryRepository, ExpenseCategoryRepository>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;
                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(7);
            }).AddEntityFrameworkStores<AppDataContext>();

            services.AddLogging();
        }
    }
}