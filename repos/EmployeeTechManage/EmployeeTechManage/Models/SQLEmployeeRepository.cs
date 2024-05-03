using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeTechManage.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext _context)
        {
            context = _context;
        }
        IQueryable<Employee> employees=>context.employees;

        IQueryable<Employee> IEmployeeRepository.employees => context.employees;

        Employee IEmployeeRepository.GetEmployee(int Id)
        {
            return context.employees.Find(Id);
        }
        Employee IEmployeeRepository.AddEmployee(Employee employee)
        {
           context.employees.Add(employee);
            context.SaveChanges();                 

            return employee;
        }
       

        public Employee UpdateEmployee(Employee changedEmployee)
        {
           var employee= context.employees.Attach(changedEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return changedEmployee;
        }
    }
}
