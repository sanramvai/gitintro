using Bethanypieshop.Models;
using Bethanypieshop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bethanypieshop.Components
{
    public class ShoppingCartSummary:ViewComponent
    {
        private IShoppingCart _shoppingCart { get; set; }
        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
           var shoppingview=new ShoppingCartViewModel(_shoppingCart,_shoppingCart.GetShoppingCartTotal());
            return View(shoppingview);

            
        }

    }
}
