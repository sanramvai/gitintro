using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public Product(bool stock=false)
        {
            InStock = stock;
        }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Product  Related{ get; set; }
        public string Category { get; set; } = "Watersports";
        public bool InStock { get; }
        public static Product[] Products()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Price = 275M,
                Category="swimmingsports"
            };
            Product lifejacket = new Product(true)
            {
                Name = "Lifejacket",
                Price = 48.95M
            };
            kayak.Related = lifejacket;
            return new Product[] { kayak, lifejacket, null };

        }
    }
}
