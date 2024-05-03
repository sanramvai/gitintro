using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Controllers
{
    public class HomeController:Controller
    {
        private IStoreRepository Repository;
        public int PageSize = 4;
        public HomeController(IStoreRepository repository)
        {
            Repository = repository;
        }
        public ViewResult Index(int productPage=1)
        {
            return View(Repository.Products.OrderBy(p=>p.ProductID).Skip((productPage-1)*PageSize).Take(PageSize));
        }
    }
}
