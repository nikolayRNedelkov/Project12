using Project12.Repositories.Base.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project12.Repositories.Base.Contracts
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task<SaveResult> InsertAsync(T model);

        Task<SaveResult> UpdateAsync(T model);

        Task<SaveResult> DeleteAsync(int id);
    }
}
