using Aromas.Domain.Entities;
using System.Collections.Generic;

namespace Aromas.App.Interface
{
    public interface IProductAppService : IAppServiceBase<Product>
    {
        public List<Product> GetByIsInStock(bool isInStock);
        public List<Product> GetByCategoryId(int id);

    }
}
