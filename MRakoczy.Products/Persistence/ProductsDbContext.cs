using Microsoft.EntityFrameworkCore;
using MRakoczy.Application.Models;

namespace MRakoczy.Application.Persistence
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }
    }
}
