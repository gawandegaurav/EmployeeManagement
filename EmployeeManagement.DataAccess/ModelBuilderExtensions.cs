using EmployeeManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Employee>().HasData(
                new Employee() { Id = 1, Name = "Ram", Department = Department.IT, Email = "Ram@Primes.com" },
                new Employee() { Id = 2, Name = "Sham", Department = Department.IT, Email = "Sham@Primes.com" }
            );
        }
    }
}