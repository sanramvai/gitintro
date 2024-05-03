using FinalSportStore.Models;
using FinalSportStore.Models.ViewModel;
using FinalSportStore.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSportStore.Controllers
{
    public class HomeController:Controller
    {
        public IStoreRepository Repository{ get; set; }
        public int ProdPerPage = 3;
        public HomeController(IStoreRepository repository)
        {
            Repository = repository;
        }
        public IActionResult Index(string category,int pageNo = 1)
        {
            return View(new ProductListViewModel { Products = Repository.Products.Where(p=>category==null||p.Category == category).OrderBy(p => p.ProductID).Skip(ProdPerPage * (pageNo - 1)).Take(ProdPerPage),
            PagingInfo=new PageInfo {CurrentPage=pageNo,
                ProductPerPage=ProdPerPage,
                TotalItems=Repository.Products.Count()},
            CurrentCategory=category
            
            });
        }
    }
}
