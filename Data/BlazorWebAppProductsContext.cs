using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorWebAppProducts.Models;

namespace BlazorWebAppProducts.Data
{
    public class BlazorWebAppProductsContext : DbContext
    {
        public BlazorWebAppProductsContext (DbContextOptions<BlazorWebAppProductsContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorWebAppProducts.Models.Product> Product { get; set; } = default!;
    }
}
