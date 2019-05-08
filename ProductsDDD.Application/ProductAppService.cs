using ProductsDDD.Application.Interface;
using ProductsDDD.Domain.Entities;
using ProductsDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;


namespace ProductsDDD.Application
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService)
        {
            _productService = productService;
        }
        public Product Create(Product product)
        {
            _productService.Create(product);
            return product;
        }

        public List<Product> Get()

        {
            return _productService.Get();
        }

        public Product Get(string id)
        {
            return _productService.Get(id);
        }

        public void Remove(Product product)
        {
            _productService.Remove(product);
        }

        public void Remove(string id)
        {
            _productService.Remove(id);
        }

        public void Update(string id, Product product)
        {
            _productService.Update(id, product);
        }
    }
}
