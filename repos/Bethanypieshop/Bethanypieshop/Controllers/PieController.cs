
using Bethanypieshop.Models;
using Bethanypieshop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bethanypieshop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICatigoryRepository _CatigoryRepository;
        public PieController(IPieRepository pieRepository,ICatigoryRepository CatigoryRepository)
        {
            _pieRepository = pieRepository;
            _CatigoryRepository = CatigoryRepository;

        }


        public IActionResult List(string? category)
        {
            IEnumerable<Pie> piem;
            string? currentCategory;
            if (string.IsNullOrEmpty(category))
            {
                piem = _pieRepository.AllPies.OrderBy(p=>p.PieId);
                currentCategory = "All Pies";
            }
            else
            {
                 piem = _pieRepository.AllPies.Where(p => p.Catigory.CatigoryName == category).OrderBy(p=>p.PieId);
                currentCategory = _CatigoryRepository.AllCatigories.FirstOrDefault(c => c.CatigoryName == category)?.CatigoryName;

                
            }

            return View(new PieListViewModel(piem, currentCategory));
        }
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if(pie == null)
            {
                return NotFound();

            }
            return View(pie);

        }
    }
}
