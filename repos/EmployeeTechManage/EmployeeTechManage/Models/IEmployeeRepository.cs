using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTechManage.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IQueryable<Employee> employees { get;}
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
    }
}
