using MongoDB.Driver;
using ProductsDDD.Domain.Entities;
using ProductsDDD.Domain.Interfaces;
using ProductsDDD.Domain.Interfaces.Repositories;
using ProductsDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsDDD.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;
        private readonly ProductsMongoDBContext _productsMongoDBContext;

        public ProductRepository(ProductsMongoDBContext productsMongoDBContext)
        {
            _products = productsMongoDBContext.Database.GetCollection<Product>("Products");
        }

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public List<Product> Get()
        {
            return _products.Find(product => true).ToList();
        }

        public Product Get(string id)
        {
            return _products.Find<Product>(product => product.Id == id).FirstOrDefault();
        }

        public void Remove(Product productIn)
        {
            _products.DeleteOne(product => product.Id == productIn.Id);
        }

        public void Remove(string id)
        {
            _products.DeleteOne(product => product.Id == id);
        }

        public void Update(string id, Product productIn)
        {
            _products.ReplaceOne(product => product.Id == id, productIn);
        }
    }
}
