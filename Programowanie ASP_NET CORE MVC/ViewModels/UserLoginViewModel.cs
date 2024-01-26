using System.ComponentModel.DataAnnotations;

namespace Programowanie_ASP_NET_CORE_MVC.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
