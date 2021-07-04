using System.ComponentModel.DataAnnotations;

namespace Heart.API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email não pode ser vazio")]
        public string Email {get; set;}

        [Required(ErrorMessage = "A senha não pode ser vazia")]
        public string Password { get; set; }
    }
}