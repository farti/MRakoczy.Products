using System.Threading.Tasks;

namespace MRakoczy.Products.Models.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}