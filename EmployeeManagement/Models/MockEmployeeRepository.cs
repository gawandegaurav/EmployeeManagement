using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>(){
                    new Employee(){Id = 1,Name = "Ram", Department = Department.IT, Email = "Ram@Primes.com"},
                    new Employee(){Id = 2,Name = "Sham", Department = Department.IT, Email = "Sham@Primes.com"},
                    new Employee(){Id = 3,Name = "Seema", Department = Department.HR, Email = "Seema@Primes.com"}
                };
        }

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(emp => emp.Id == id);
        }

        public Employee Create(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> Read()
        {
            return _employees;
        }

        public Employee Update(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Employee Delete(Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }
}