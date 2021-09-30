using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Repositories;
using Aromas.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Aromas.Infra.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        
    }
}