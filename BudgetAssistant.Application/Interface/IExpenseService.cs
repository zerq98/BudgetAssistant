using BudgetAssistant.Application.Dto.Expense;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAssistant.Application.Interface
{
    public interface IExpenseService
    {
        Task<List<ViewExpenseDto>> GetAll(string userId);

        Task<List<ViewExpenseDto>> GetAllFromCategory(int categoryId);

        Task<bool> AddExpense(CreateExpenseDto dto);

        Task<bool> RemoveExpense(int id);

    }
}
