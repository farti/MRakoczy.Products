using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MRakoczy.Products.Models.Domain;

namespace MRakoczy.Products.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        Task<List<Product>> List();
    }
}
