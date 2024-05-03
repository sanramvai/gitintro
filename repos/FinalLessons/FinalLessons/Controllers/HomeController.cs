using FinalLessons.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalLessons.Controllers
{
    public class HomeController : Controller
    {
        public IDataSource dataSource = new ProductDataSource();
        public IActionResult Index()
        {

            return View(dataSource.Products);
        }

       
    }
}
