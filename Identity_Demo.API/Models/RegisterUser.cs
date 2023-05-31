using System.ComponentModel.DataAnnotations;

namespace Identity_Demo.API.Models
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Username cannot be blank")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm password cannot be blank")]
        public string? ConfirmPassword { get; set; }
    }
}
