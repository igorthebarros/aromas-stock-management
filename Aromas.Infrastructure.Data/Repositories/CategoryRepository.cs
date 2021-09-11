using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Repositories;

namespace Aromas.Infra.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
    }
}