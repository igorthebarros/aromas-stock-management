using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Repositories;

namespace Aromas.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
    }
}