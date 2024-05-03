using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSportStore.Models
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products{ get; set; }
    }
}
