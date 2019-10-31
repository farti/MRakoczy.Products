using System.Threading.Tasks;

namespace MRakoczy.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}