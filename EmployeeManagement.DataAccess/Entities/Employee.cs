using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.DataAccess.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Office email")]
        public string Email { get; set; }

        public Department Department { get; set; }
    }
}