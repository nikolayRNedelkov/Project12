using Microsoft.AspNetCore.Http;
using Project12.Services.Base.Contracts;
using System.Security.Claims;

namespace Project12.Services.Base
{
    public class UserData : IUserData
    {
        public UserData(IHttpContextAccessor httpContextAccessor)
        {
            this.UserId = httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.Name)?.Value;
        }

        public string UserId { get; set; }
    }
}
