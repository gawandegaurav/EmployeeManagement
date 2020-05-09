using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManagement.DataAccess.Entities;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(AppDbContext appDbContext, ILogger<EmployeeRepository> logger)
        {
            _dbContext = appDbContext;
            _logger = logger;
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
            _logger.LogTrace("Log trace.");
            _logger.LogDebug("Log debug.");
            _logger.LogInformation("Log information.");
            _logger.LogWarning("Log warning.");
            _logger.LogError("Log error.");
            _logger.LogCritical("Log critical.");

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
