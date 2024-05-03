using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class HomeController:Controller
    {
        public IStoreRepository Repository;
        public HomeController(IStoreRepository storeRepository)
        {
            Repository = storeRepository;
        }
        public ViewResult Index()
        {
            return View(Repository.Products);
        }
    }
}
