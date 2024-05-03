using Microsoft.AspNetCore.Mvc;

namespace Features.Controllers
{
    public class HomeController:Controller

    {
        public ViewResult Index()
        { return View(new string[] {"C#","Java","Cobol"}); }

    }
}
