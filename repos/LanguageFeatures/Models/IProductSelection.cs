using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public interface IProductSelection
    {
        IEnumerable<Product> Getproducts { get; }
        public IEnumerable<string> Names => Getproducts.Select(p => p.Name);
    }
}
