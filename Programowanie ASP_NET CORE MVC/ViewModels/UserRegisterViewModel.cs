using System.ComponentModel.DataAnnotations;

namespace Programowanie_ASP_NET_CORE_MVC.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Potwierdzenie hasła wymagane jest")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasło i hasło potwierdzające muszą być takie same")]
        public string? ConfirmPassword { get; set; }
    }
}
