using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MRakoczy.Application.Persistence;
using MRakoczy.Products.Interfaces;
using MRakoczy.Products.Models.Domain;

namespace MRakoczy.Products.Models.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _context;

        public ProductRepository(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);

        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _context.Remove(product);
        }

        public Task<List<Product>> List()
        {
            return _context.Products.ToListAsync();
        }
    }
}
