using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        public StoreDbContext Context { get; set; }
        public EFStoreRepository(StoreDbContext context)
        {
            Context = context;
                
        }      

        IQueryable<Product> IStoreRepository.Products => Context.Products;

    }
}
