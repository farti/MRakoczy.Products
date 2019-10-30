using Microsoft.EntityFrameworkCore;
using MRakoczy.Products.Models.Domain;

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
