﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFStoreRepository :IStoreRepository
    {
        private StoreDbContext DbContext;

        public EFStoreRepository(StoreDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public IQueryable<Product> Products => DbContext.Products;
    }
}
