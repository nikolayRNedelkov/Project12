using Project12.Services.Models.Base;
using Project12.Services.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project12.Services.Contracts
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllAsync();

        Task<UserViewModel> GetAsync(string userId);

        Task<OperationResponse> CreateAsync(UserRegistrationModel model);
    }
}
