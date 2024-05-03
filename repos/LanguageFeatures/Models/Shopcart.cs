using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Shopcart : IProductSelection
    {
        private List<Product> products = new List<Product>();
        public Shopcart(params Product[] prod)
        {
            products.AddRange(prod);
        }
        public IEnumerable<Product> Getproducts { get => products; }

    }
}
