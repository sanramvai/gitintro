using Bethanypieshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bethanypieshop.Controllers
{
    public class OrderController:Controller

    {
        public IShoppingCart _IShoppingCart { get; set; }
        public IOrderRepository _orderRepository { get; set; }
        public OrderController(IShoppingCart IShoppingCart, IOrderRepository orderRepository)
        {
            _IShoppingCart=IShoppingCart;
            _orderRepository=orderRepository;

        }
        public IActionResult Checkout()
        {
            return View();
        
        }
        [HttpPost]
        public IActionResult checkout(Order order)
        {
            var shoppingcartItems = _IShoppingCart.GetShoppingCartItems();
            _IShoppingCart.ShoppingCartItems= shoppingcartItems;
            if(shoppingcartItems!=null && shoppingcartItems.Count()>0)
            {
                if(ModelState.IsValid)
                {
                    _orderRepository.CreateOrder(order);
                    _IShoppingCart.ClearCart();
                    return RedirectToAction("CheckOutComplete");
                }
                ModelState.AddModelError("", "Your Cart is empty");
            }
            return View(order);
        }
        public IActionResult CheckOutComplete()
        {
            ViewBag.CheckOutMessage = "Thank you for your order You will enjoy our delicious pies";
            return View();
        }

    }
}
