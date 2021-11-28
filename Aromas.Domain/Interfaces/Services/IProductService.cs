using Aromas.Domain.Entities;
using System.Collections.Generic;

namespace Aromas.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        public List<Product> GetByIsInStock(bool isInStock);
        public List<Product> GetByCategoryId(int id);
    }
}