using System.ComponentModel.DataAnnotations;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required]
        [ValidEmailDomain(allowedDomain: "primetech.com", ErrorMessage = "Email domain must be primetech.com")]
        [Display(Name = "Office email")]
        public string Email { get; set; }

        public Department Department { get; set; }

        public IFormFile Photo { get; set; }
    }
}