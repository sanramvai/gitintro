using Bethanypieshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bethanypieshop.Pages
{
    public class CheckoutModel : PageModel
    {

        private readonly IShoppingCart shoppingCart;
        private readonly IOrderRepository IOrderRepository;
        public CheckoutModel(IShoppingCart shoppingCart, IOrderRepository iOrderRepository)
        {
            this.shoppingCart = shoppingCart;
            IOrderRepository = iOrderRepository;
          
        }

        public Order order {  get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost(Order order) 
        {
            order.OrderPlaced = DateTime.Now;
            var shoppingcartItems = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = shoppingcartItems;
           if (shoppingcartItems != null && shoppingcartItems.Count() > 0)
            {
                if (ModelState.IsValid)
                {
                    IOrderRepository.CreateOrder(order);
                    shoppingCart.ClearCart();
                    return RedirectToPage("CheckOutComplet");


                }
               

            }
            return Page();
        }
    }
}
