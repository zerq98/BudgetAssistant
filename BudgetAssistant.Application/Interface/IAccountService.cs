using BudgetAssistant.Application.Dto.Account;
using System.Threading.Tasks;

namespace BudgetAssistant.Application.Interface
{
    public interface IAccountService
    {
        public Task<bool> Register(RegisterDto dto);

        public Task<string> Login(LoginDto dto);

        public Task Logout();
    }
}