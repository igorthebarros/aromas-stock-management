using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Repositories;
using Aromas.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Aromas.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        protected ApplicationDbContext Db = new ApplicationDbContext();

        public List<Product> GetByCategoryId(int id)
        {
            return Db.Set<Product>().Where(x => x.CategoryId == id).ToList();
        }
        public List<Product> GetByIsInStock(bool isInStock)
        { 
            return Db.Set<Product>().Where(x => x.IsInStock == isInStock).ToList(); 
        }
    }
}