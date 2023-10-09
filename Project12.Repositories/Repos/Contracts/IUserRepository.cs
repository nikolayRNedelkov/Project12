using Project12.Repositories.Base.Models;
using Project12.Repositories.Filters.Users;
using Project12.Repositories.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project12.Repositories.Repos.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(UserFilter filter);

        Task<User> GetAsync(string userId);

        Task<SaveResult> UpdateAsync(User model);
    }
}
