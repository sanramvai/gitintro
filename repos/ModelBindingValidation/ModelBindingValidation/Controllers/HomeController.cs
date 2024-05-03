using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelBindingValidation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingValidation.Controllers
{
    public class HomeController : Controller
    {
        private IRepository Repository;

        public HomeController(IRepository repo)
        {
            Repository = repo;
        }
        public IActionResult Index(int id=4)
        {
            
            return View(Repository[id]);

        }
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            return View("Index", employee);
        }
       
        
        public IActionResult DisplayAction([Bind(Prefix =nameof(Employee.HomeAddress))]   PersonAddress person)
        {
            return View(person);
        }
        public IActionResult Places(string[] places) => View(places);
        public IActionResult CollectionPlaces(List<string> Listplaces)
        {
            return View(Listplaces);
        }
        [HttpGet]
        public IActionResult Address() => View();

        [HttpPost]
        public IActionResult Address(List<PersonAddress> address) => View(address);



    }
}
