using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAssistant.Domain.Interfaces
{
    public interface IBaseRepository<T> where T: class
    {
        public IQueryable<T> GetAll(string userId);

        public Task<int> AddNewAsync(T model);

        public Task<int> EditAsync(T model);

        public Task<T> GetByIdAsync(int modelId);

        public Task RemoveAsync(T model);
    }
}
