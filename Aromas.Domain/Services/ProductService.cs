using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Repositories;
using Aromas.Domain.Interfaces.Services;
using System.Collections.Generic;

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
        public List<Product> GetByCategoryId(int id)
        {
            return _productRepository.GetByCategoryId(id);
        }
        public List<Product> GetByIsInStock(bool isInStock)
        {
            return _productRepository.GetByIsInStock(isInStock); 
        }

    }
}