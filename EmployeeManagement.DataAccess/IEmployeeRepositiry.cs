using System.Collections.Generic;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.DataAccess
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);

        Employee Create(Employee employee);

        IEnumerable<Employee> Read();

        Employee Update(Employee employee);

        Employee Delete(Employee employee);
    }
}