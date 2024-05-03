using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSportStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext Context;
        public EFStoreRepository(StoreDbContext context)
        {
            Context = context;
        }
        public IQueryable<Product> Products => Context.Products;
    }
}
