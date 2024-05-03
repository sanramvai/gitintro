using Bethanypieshop.Models;
using Bethanypieshop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bethanypieshop.Controllers
{
    public class ShoppingCartController:Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IPieRepository _pieRepository;
        public ShoppingCartController(IShoppingCart shoppingCart,IPieRepository pieRepository )
        {
            _pieRepository= pieRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var item = _shoppingCart.GetShoppingCartItems();
            
            _shoppingCart.ShoppingCartItems = item;
            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);

        }
        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie =_pieRepository.AllPies.FirstOrDefault(s=>s.PieId == pieId);
            if (selectedPie != null)
            {
                _shoppingCart.AddToCart(selectedPie);
            }
            return RedirectToAction("Index");

        }
        public RedirectToActionResult RemoveFromCart(int pieId)

        {
            var selectedPie=_pieRepository.AllPies.SingleOrDefault(s=>s.PieId == pieId);
            if(selectedPie != null)
            { 
                _shoppingCart.RemoveFromCart(selectedPie);

            }
            return RedirectToAction("Index");
        }
    }
}
