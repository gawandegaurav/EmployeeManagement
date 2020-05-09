using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords did not matched.")]
        public string ConfirmPassword { get; set; }
    }
}