

using Bethanypieshop.Models;

namespace Bethanypieshop.ViewModels
{
    public class PieListViewModel
    {

        public IEnumerable<Pie> Pies { get; } 
        public string? CurrentCatigory {  get; set; }
        public PieListViewModel(IEnumerable<Pie> pies, string? currentCatigory)
		{
			Pies = pies;
			CurrentCatigory = currentCatigory;
		}
	}
}
