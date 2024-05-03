using EmployeeTechManage.Models;
using EmployeeTechManage.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EmployeeTechManage.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository repository;

        // Inject IEmployeeRepository using Constructor Injection
        public int PageSize = 4;

        public IWebHostEnvironment hostingEnvironment { get; }

        public HomeController(IEmployeeRepository Repository,IWebHostEnvironment HostingEnvironment )
        {
            repository = Repository;
            hostingEnvironment = HostingEnvironment;
        }
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult EmployeeList(string dept,int empPage=1)
        {
            ViewBag.Title = "List all the Employees";
            return View(
                new EmployeeListViewModel
                {
                    Employees = repository.employees
                    .Where(d=>dept==null||dept==d.Department)
                    .OrderBy(e=>e.Id)
                    .Skip((empPage - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = empPage,
                        ItemsPerPage = PageSize,
                        TotalItems =dept==null? repository.employees.Count(): repository.employees.Where(d=>d.Department==dept).Count()
                    },
                    SelectedDepartment=dept
                });

        }

        // Retrieve employee name and return
        public ViewResult Details(int? id)
        {

            if (id !<= 0)
            {

                Employee employee = repository.GetEmployee(id.Value);
                if (employee != null)
                {
                    return View(employee);
                }
            }
            Response.StatusCode = 404;
            return View("404notFound", id.Value);

        }
        [HttpGet]
        public ViewResult CreateEmp()
        {
           return View (new DropdownListViewModel { Departmentcollection = new SelectList(repository.employees.Select(d => d.Department).Distinct()) 
           });
            

           
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {

            Employee employee = repository.GetEmployee(Id);
            EditViewModel model = new EditViewModel
            {
              
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                Departmentcollection = new SelectList(repository.employees.Select(d => d.Department).Distinct()),
                ExistingPath = employee.PhotoPath
            };
            return View(model);



        }

        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            Employee employee = repository.GetEmployee(model.Id);
            if (ModelState.IsValid)
            {
            employee.Id = model.Id;
            employee.Name = model.Name;
            employee.Email = model.Email;
            employee.Department = model.Department;

            if (model.Photo != null)
            {


                if (model.ExistingPath != null)
                {
                    string deletePhotoFile = Path.Combine(hostingEnvironment.WebRootPath, "/images/", model.ExistingPath);
                    System.IO.File.Delete(deletePhotoFile);


                }
                employee.PhotoPath = uploadPhotoToServer(model);
            }

            Employee NewEmployee = repository.UpdateEmployee(employee);
            return RedirectToAction("Details", new { Id = NewEmployee.Id });
        }

            return View(new EditViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Department = model.Department,
                Departmentcollection = new SelectList(repository.employees.Select(d => d.Department).Distinct()),
                ExistingPath = model.ExistingPath
            });

        }
        private string uploadPhotoToServer(DropdownListViewModel model)
        {
            string uploaderFileName = null;
            if (model.Photo != null)
            {

                string storedFileName = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uploaderFileName = model.Photo.FileName;
                string imagePath = Path.Combine(storedFileName, uploaderFileName);
              using(var fileStream=new FileStream(imagePath,FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uploaderFileName;

        }
        [HttpPost]
        public ActionResult CreateEmp(DropdownListViewModel emp)
        {
            if (!ModelState.IsValid)
            {
                return View(new DropdownListViewModel
                {
                    Name = emp.Name,
                    Email = emp.Email,
                    Department = emp.Department,

                    Departmentcollection = new SelectList(repository.employees.Select(d => d.Department).Distinct())
                });


            }
            string uploaderFileName = uploadPhotoToServer(emp);

            Employee employee = new Employee
            {
                Name = emp.Name,
                Email = emp.Email,
                Department = emp.Department,
                PhotoPath = uploaderFileName
            };


            Employee NewEmployee = repository.AddEmployee(employee);
            return RedirectToAction("Details", new { Id = NewEmployee.Id });

        }
    }
}
