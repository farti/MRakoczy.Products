using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MRakoczy.Application.Persistence;

namespace MRakoczy.Products.Models.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductsDbContext _context;

        public UnitOfWork(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
