using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MRakoczy.Application.Models.Domain;

namespace MRakoczy.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(Guid id);
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        Task<List<Product>> List();
    }
}
