using BudgetAssistant.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAssistant.Infrastructure
{
    public class AppDataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Budget> Budgets { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        public DbSet<Jar> Jars { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasOne(x => x.Budget)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey<Budget>(x => x.ApplicationUserId);
        }
    }
}
