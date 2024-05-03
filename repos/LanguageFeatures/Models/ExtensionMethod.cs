using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public static class ExtensionMethod
    {
        public static decimal TotalPrice(this IEnumerable<Product> productCollection)
        {
            decimal Total = 0;
            foreach(Product p in productCollection)
            {
                Total += p?.Price??0;
            }
            return Total;
        }
        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> productCollection,Func<Product,bool> selector)
        {
            foreach(Product p in productCollection)
            {
                if(selector(p))
                {
                    yield return p;
                }
            }

        }
       
        public static IEnumerable<Product> FilterByName(this IEnumerable<Product> productCollection,Func<Product,bool> selector)
        {
            foreach(Product p in productCollection)
            {
                if(selector(p))
                {
                    yield return p;
                }
            }
        }
    }
}
