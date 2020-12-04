using BudgetAssistant.Domain.Entity;
using System.Linq;

namespace BudgetAssistant.Domain.Interfaces
{
    public interface IExpenseRepository : IBaseRepository<Expense>
    {
        public IQueryable<Expense> GetAllFromCategory(int categoryId);
    }
}