using BudgetAssistant.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAssistant.Domain.Interfaces
{
    public interface IExpenseRepository : IBaseRepository<Expense>
    {
        public IQueryable<Expense> GetAllFromJar(int jarId);

        public IQueryable<Expense> GetAllFromCategory(int categoryId);
    }
}
