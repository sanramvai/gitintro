using Bethanypieshop.Models;
using Bethanypieshop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bethanypieshop.Controllers
{
    public class HomeController : Controller
    {
        private IPieRepository pieRepository;
        public HomeController(IPieRepository _PieRepository)
        {
            pieRepository= _PieRepository;
                
        }
        public IActionResult Index()
        {
            var pieweek = pieRepository.PiesOfTheWeek;
            var homeviewPie = new HomeViewModel(pieweek);
            return View(homeviewPie);
        }

        public IActionResult About()
        {
            RecordInSession("About");
            return View();
        }

        private void RecordInSession(string action)
        {
            var paths = HttpContext.Session.GetString("actions") ?? string.Empty;
            HttpContext.Session.SetString("actions", paths + ";" + action);
        }
    }
}
