using System.Threading.Tasks;
using MRakoczy.Application.Interfaces;

namespace MRakoczy.Application.Persistence
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
