using ProductsDDD.Domain.Entities;
using ProductsDDD.Domain.Interfaces.Repositories;
using ProductsDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ProductsDDD.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product Create(Product product)
        {
            _productRepository.Create(product);
            return product;
        }

        public List<Product> Get()
        {
            return _productRepository.Get();
        }

        public Product Get(string id)
        {
            return _productRepository.Get(id);
        }

        public void Remove(Product product)
        {
            _productRepository.Remove(product);
        }

        public void Remove(string id)
        {
            _productRepository.Remove(id);
        }

        public void Update(string id, Product product)
        {
            _productRepository.Update(id, product);
        }
    }
}
