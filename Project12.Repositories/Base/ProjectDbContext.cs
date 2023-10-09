using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project12.Repositories.Models.Roles;
using Project12.Repositories.Models.Users;

namespace Project12.Repositories.Base
{
    public class ProjectDbContext : IdentityDbContext<User, Role, string>
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }
    }
}
