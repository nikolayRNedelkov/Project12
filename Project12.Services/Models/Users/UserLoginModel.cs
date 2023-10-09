using System.ComponentModel.DataAnnotations;

namespace Project12.Services.Models.Users
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Полето е задължително!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        public string Password { get; set; }
    }
}
