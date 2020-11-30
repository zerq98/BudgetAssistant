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
                .AddEntityFrameworkStores<AppDataContext>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(7);
            });

            services.AddLogging();
        }
    }
}