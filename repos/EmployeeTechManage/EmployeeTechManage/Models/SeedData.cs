using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTechManage.Models
{
    public static class SeedData
    {
        public static void seed(IApplicationBuilder builder)
        {
            AppDbContext context = builder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            if (!context.employees.Any())
            {
                context.employees.AddRange(
                     new Employee
                     {
                         
                         Name = "Mary",
                         Department =  "IT" ,
                         Email = "mary@prtech.com"
                     },
                    new Employee
                    {
                        
                        Name = "John",
                        Department = "HR",
                        Email = "john@prtech.com"
                    },
                    new Employee
                    {
                        
                        Name = "Luca",
                        Department = "IT",
                        Email = "Luca@tech.com"
                    },
                    new Employee
                    {
                        
                        Name = "Adithi",
                        Department = "HR",
                        Email = "Adithi@ptech.com"
                    },
                    new Employee
                    {
                        
                        Name = "kum",
                        Department = "sales",
                        Email = "kum@pragimtech.com"
                    },
                    new Employee
                    {
                        
                        Name = "yousaf",
                        Department = "Marketing",
                        Email = "yousaf@tech.com"
                    },
                    new Employee
                    {
                        
                        Name = "Vaidehi",
                        Department = "IT",
                        Email = "vaidehi@tech.com"
                    },
                    new Employee
                    {
                        
                        Name = "Yash",
                        Department = "sales",
                        Email = "yash@tech.com"
                    },
                    new Employee
                    {

                        Name = "sachin",
                        Department = "IT",
                        Email = "sachin@tech.com"
                    },
                    new Employee
                    {

                        Name = "dhanya",
                        Department = "IT",
                        Email = "dhanya@tech.com"
                    }


                    );
                context.SaveChanges();
            }
            
        }
    }
}
