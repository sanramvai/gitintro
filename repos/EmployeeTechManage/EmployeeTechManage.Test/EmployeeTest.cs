using EmployeeTechManage.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using System.Linq;
using EmployeeTechManage.Controllers;

namespace EmployeeTechManage.Test
{
   
   public class EmployeeTest
    {
        [Fact]
        public void Can_Use_Repository()
        {
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(e => e.employees).Returns((new Employee[]
            { new Employee{Name="Karl",Department="IT" },
              new Employee{Name="Karl",Department="HR" },
              new Employee{Name="Karl",Department="sales" }

            }).AsQueryable<Employee>()) ;
           // HomeController controller = new HomeController(mock.Object,e);
        }
    }
}
