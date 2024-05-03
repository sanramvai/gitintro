using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
    public class HomeController:Controller
    {
        Dictionary<string,Product> result = new Dictionary <string,Product>();
        public ViewResult Index()
        {
            foreach (Product p in Product.Products())
            {
                string Name = p?.Name;
                decimal? price = p?.Price;
                string related = p?.Related?.Name?? "<NONE>";
                string category = p?.Category;
                bool? stock = p?.InStock;
                if (Name != null)
                {
                    result.Add(Name, p);
                }
                //result.Add($"{Name} cost {price} related to {related} catergory {category} stock {stock}");
            }
            return View(result);

        }
        public ViewResult PatternMatchingSwitch()
        {
            object[] data2 = new object[] { 275M, 29.95M,"apple", "orange", 100, 10 };
            decimal total = 0;
            for (int i=0;i<data2.Length-1;i++)
            {
                switch(data2[i])
                {
                    case decimal d:                        
                        total += d;
                        break;
                    case int intvalue when intvalue > 50:
                        total += intvalue;
                        break;

                }

            }
            return View( new string[] { $"Total: {total:C2}" });
        }
         public ViewResult UseExtentionMethod()
        {
            ShoppingCart cart = new ShoppingCart()
            {
                products = Product.Products()
            };
            Product[] productArray =
             {
            new Product {Name = "Kayak", Price = 275M},
            new Product {Name = "Lifejacket", Price = 48.95M},
            new Product {Name = "Soccer ball", Price = 19.50M},
            new Product {Name = "Corner flag", Price = 34.95M}
            };

             decimal cartTotal = cart.TotalPrice();
             decimal arrayTotal= productArray.FilterByPrice(p=>p.Price<20).TotalPrice();
             decimal nameFilterTotal = productArray.FilterByName(p=>p.Name[0]=='s').TotalPrice();
             return View(new string[] { $"Cart Total: {cartTotal:C2}", $"Array Total: {arrayTotal:C2} Fillteredby Name {nameFilterTotal}" });
            //return View(cart.Getproducts.Select(p => p.Name));
        }
        public ViewResult UseInterface()
        {
            IProductSelection cart = new Shopcart(

            new Product { Name = "Rope", Price = 275M },
            new Product { Name = "Vest", Price = 48.95M },
            new Product { Name = "stick", Price = 19.50M },
            new Product { Name = "ball", Price = 34.95M }
            );
            return View(cart.Names);
        }
        public async Task<ViewResult> UseAsyncProgram()
        {
            List<string> output = new List<string>();
           await foreach (long? len in  MyAsynchonousMethod.GetPageLengths(output,
            "apress.com", "microsoft.com"))
            {
                output.Add($"Page length: { len}");
            }
            return View(output);
        }
    }
}
