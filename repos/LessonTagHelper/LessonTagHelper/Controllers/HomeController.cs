using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonTagHelper.Models
{
    public class HomeController:Controller
    {
        public ViewResult Contact()
        {
            return View();
        }
        public ViewResult Index()
        {
            var model = new EmployeeViewModel
            {
                Employees = new List<Employee>
           {
               new Employee {
                   Name = "sandhya",
                   JobTitle = "Software Developer",
                   Profile = "C#/ASP.NET Developer",
                   Friends = new List<Friend>
                   {
                       new Friend { Name = "sachin" },
                       new Friend { Name = "vaidu" },
                       new Friend { Name = "yash" },
                   }
               },
               new Employee {
                   Name = "James Bond",
                   JobTitle = "MI6 Agent",
                   Profile = "Has licence to kill",
                   Friends = new List<Friend>
                   {
                       new Friend { Name = "James Gordon" },
                       new Friend { Name = "Robin Hood" },
                   }
               },
           }
            };
            return View(model);
        }


    }
}
