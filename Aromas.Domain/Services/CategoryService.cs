using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Repositories;
using Aromas.Domain.Interfaces.Services;

namespace Aromas.Domain.Services
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
            : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}