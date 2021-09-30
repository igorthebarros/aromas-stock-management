using Aromas.Domain.Entities;
using System.Collections.Generic;

namespace Aromas.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        public List<Product> GetByIsInStock(bool isInStock);
        public List<Product> GetByCategoryId(int id);
    }
}