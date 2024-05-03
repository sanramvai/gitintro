
using Microsoft.EntityFrameworkCore;

namespace Bethanypieshop.Models
{
    public class PieRepository : IPieRepository

    {
        private BethanypieshopDbContext _bethanypieshopDbContext;
        public PieRepository(BethanypieshopDbContext bethanypieshopDbContext)
        {
            _bethanypieshopDbContext = bethanypieshopDbContext;
        }

        public IEnumerable<Pie> AllPies => _bethanypieshopDbContext.Pies.Include(p=>p.Catigory);

        public IEnumerable<Pie> PiesOfTheWeek =>_bethanypieshopDbContext.Pies.Include(p=>p.Catigory).Where(p=>p.IsPieOfTheWeek);

        public Pie? GetPieById(int PieId)
        {
          return _bethanypieshopDbContext.Pies.FirstOrDefault(p=>p.PieId == PieId);
        }
    }
}
