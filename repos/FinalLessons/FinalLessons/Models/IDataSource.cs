using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalLessons.Models
{
    public interface IDataSource
    {
        IEnumerable<Product> Products { get; }
    }
}
