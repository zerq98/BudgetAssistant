using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAssistant.Domain.Interfaces
{
    public interface ILogRepository
    {
        public Task Log(LogLevel logLevel, string message);
    }
}
