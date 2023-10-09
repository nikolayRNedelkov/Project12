using Project12.Repositories.Models.Users;
using Project12.Utilities.Mapper;

namespace Project12.Services.Models.Users
{
    public class UserRegistrationModel : IMapFrom<User>, IMapTo<User>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }

        public string Email { get; set; }
    }
}
