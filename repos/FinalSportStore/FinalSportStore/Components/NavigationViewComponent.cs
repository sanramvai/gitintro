using FinalSportStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSportStore.Components
{
    public class NavigationViewComponent:ViewComponent
    {
        private IStoreRepository Repository;
        public NavigationViewComponent(IStoreRepository repository)
        {
            Repository = repository;
        }
       public IViewComponentResult Invoke()
        {
            ViewBag.ifSelected = RouteData.Values["category"];
            return View(Repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
            string[] results=Target.Invoke
        }
    }
}
