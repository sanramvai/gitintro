using Bethanypieshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bethanypieshop.Components
{
    public class CatigoryMenu:ViewComponent

    {
        private ICatigoryRepository ICatigoryRepository;
        public CatigoryMenu(ICatigoryRepository _ICatigoryRepository)
        {
            ICatigoryRepository = _ICatigoryRepository;     
        }
        public IViewComponentResult Invoke()
        {
            return View(ICatigoryRepository.AllCatigories);
        }
    }
}
