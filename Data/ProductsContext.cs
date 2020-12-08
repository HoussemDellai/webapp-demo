using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppCore.Models;

namespace WebAppCore.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext (DbContextOptions<ProductsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<WebAppCore.Models.Product> Product { get; set; }
    }
}
