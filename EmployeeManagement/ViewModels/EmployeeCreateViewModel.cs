using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeCreateViewModel
    {

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Office email")]
        public string Email { get; set; }

        public Department Department { get; set; }

        public IFormFile Photo { get; set; }
    }
}
