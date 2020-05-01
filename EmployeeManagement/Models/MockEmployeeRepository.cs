using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>(){
                    new Employee(){Id = 1,Name = "Ram", Department = "IT", Email = "Ram@Primes.com"},
                    new Employee(){Id = 2,Name = "Sham", Department = "IT", Email = "Sham@Primes.com"},
                    new Employee(){Id = 3,Name = "Seema", Department = "HR", Email = "Seema@Primes.com"}
                };
        }

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(emp => emp.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}