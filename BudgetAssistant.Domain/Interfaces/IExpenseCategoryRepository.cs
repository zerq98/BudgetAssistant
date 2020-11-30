using BudgetAssistant.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAssistant.Domain.Interfaces
{
    public interface IExpenseCategoryRepository : IBaseRepository<ExpenseCategory>
    {
        public IQueryable<ExpenseCategory> GetAllFromJar(int jarId);
    }
}
