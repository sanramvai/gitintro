
namespace Bethanypieshop.Models
{
    public class CatigoryRepository : ICatigoryRepository
    {
        private readonly BethanypieshopDbContext _bethanypieshopDbContext;
        public CatigoryRepository(BethanypieshopDbContext bethanypieshopDbContext)
        {
            _bethanypieshopDbContext = bethanypieshopDbContext;

        }
        public IEnumerable<Catigory> AllCatigories =>
        _bethanypieshopDbContext.Catigories.OrderBy(c => c.CatigoryId);
    }

   
       
   

}
