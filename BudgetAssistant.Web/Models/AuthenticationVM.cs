using BudgetAssistant.Application.Dto.Account;

namespace BudgetAssistant.Web.Models
{
    public class AuthenticationVM
    {
        public LoginDto Login { get; set; }
        public RegisterDto Register { get; set; }
    }
}