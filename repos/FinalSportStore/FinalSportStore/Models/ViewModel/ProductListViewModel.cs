using FinalSportStore.Views.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSportStore.Models.ViewModel
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
