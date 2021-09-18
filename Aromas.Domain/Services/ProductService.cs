using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Repositories;
using Aromas.Domain.Interfaces.Services;

namespace Aromas.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
            : base(productRepository)
        {
            _productRepository = productRepository;
        }
    }
}