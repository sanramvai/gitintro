using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalSportStore.Infrastructure;
using FinalSportStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalSportStore.Pages
{
    public class CartModel : PageModel
    {
        public string ReturnUrl { get; set; }
        public Cart cart  { get; set; }
        private IStoreRepository repository;
        public CartModel(IStoreRepository repo)
        {
            repository = repo;
        }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl;
            cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            

        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p=>p.ProductID==productId);
            cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            //Cart = new Cart();
            cart.AddItem(product, 1);
            HttpContext.Session.SetJson("Cart", cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

    }
}
