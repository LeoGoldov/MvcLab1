using System.Collections.Generic;
using MvcLab1.Models;

namespace MvcLab1.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        IEnumerable<Product> GetByСategoty(string categoty);

        IEnumerable<Product> GetInStock();
    }
}
