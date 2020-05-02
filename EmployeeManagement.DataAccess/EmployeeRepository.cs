using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public Employee Create(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(Employee employee)
        {
            var emp = _dbContext.Employees.FirstOrDefault(x => x.Id == employee.Id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(emp);
                _dbContext.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return _dbContext.Employees.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> Read()
        {
            return _dbContext.Employees;
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _dbContext.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return employeeChanges;

        }
    }
}
