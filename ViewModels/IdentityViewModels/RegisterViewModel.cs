using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.ViewModels.IdentityViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not matching")]
        public string ConfirmPassword { get; set; }
    }
}
