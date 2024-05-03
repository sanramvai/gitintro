using EmployeeTechManage.Models;
using EmployeeTechManage.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTechManage.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private readonly IEmployeeRepository employeeRepository;

        public NavigationMenuViewComponent(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;

        }
        public IViewComponentResult Invoke()
        
        {
            return View(new DepartmentSelectViewModel
            {
                DepartmentList = employeeRepository.employees.Select(d => d.Department).Distinct().OrderBy(o => o),
                selectedDepartment= (string)RouteData?.Values["dept"]
            });
        }
    }
}
