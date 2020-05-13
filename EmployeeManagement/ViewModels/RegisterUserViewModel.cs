using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [EmailAddress]
        [ValidEmailDomain(allowedDomain: "primetech.com", ErrorMessage = "Email domain must be primetech.com")]
        //[Remote(action: "IsEmailInUseAsync", controller: "Account",  HttpMethod ="Get")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords did not matched.")]
        public string ConfirmPassword { get; set; }
    }
}