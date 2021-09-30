using Aromas.App.Interface;
using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Services;

namespace Aromas.App.Services
{
    public class CategoryAppService : AppServiceBase<Category>, ICategoryAppService
    {
        private readonly ICategoryService _categoryService;

        public CategoryAppService(ICategoryService categoryService)
            : base(categoryService)
        {
            _categoryService = categoryService;
        }
    }
}