using Microsoft.AspNetCore.Identity;
using Project12.Repositories.Base.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project12.Repositories.Models.Roles
{
    [Table("AspNetRoles")]
    public class Role : IdentityRole, IDataModel<string>
    {
    }
}
