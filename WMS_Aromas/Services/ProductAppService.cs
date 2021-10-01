using Aromas.App.Interface;
using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Aromas.App.Services
{
    public class ProductAppService : AppServiceBase<Product>, IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService) : base(productService)
        {
            _productService = productService;
        }

        public List<Product> GetByCategoryId(int id)
        {
            return _productService.GetByCategoryId(id);
        }

        public List<Product> GetByIsInStock(bool isInStock)
        {
            return _productService.GetByIsInStock(isInStock);
        }
    }
}