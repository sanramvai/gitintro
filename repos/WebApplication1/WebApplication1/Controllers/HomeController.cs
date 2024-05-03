﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
   
        public class HomeController : Controller
        {
            private const string SessionName = "_Name";
            private const string SessionAge = "_Age";

            public IActionResult Index()
            {
                // Set session data
                HttpContext.Session.SetString(SessionName, "Jarvik");
                HttpContext.Session.SetInt32(SessionAge, 24);

                return View();
            }

            public IActionResult About()
            {
                // Retrieve session data
                ViewBag.Name = HttpContext.Session.GetString(SessionName);
                ViewBag.Age = HttpContext.Session.GetInt32(SessionAge);
                ViewData["Message"] = "ASP.NET Core!";

                return View();
            }

            public IActionResult Contact()
            {
                ViewData["Message"] = "Your contact page.";
                return View();
            }

            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    


}

