using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalSportStore.Views.ViewModel
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ProductPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages =>
        (int)Math.Ceiling((decimal)TotalItems / ProductPerPage);

    }
}
