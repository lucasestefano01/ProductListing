using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProductsAPI.Models;
using ProductsAPI.ServicesContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _products;
        private readonly ProductsMongoDBContext _productsMongoDBContext;

        public ProductService(ProductsMongoDBContext productsMongoDBContext)
        {
            _products = productsMongoDBContext.Database.GetCollection<Product>("Products");
        }

        public List<Product> Get()
        {
            return _products.Find(product => true).ToList();
        }

        public Product Get(string id)
        {
            return _products.Find<Product>(product => product.Id == id).FirstOrDefault();
        }

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, Product productIn)
        {
            _products.ReplaceOne(product => product.Id == id, productIn);
        }

        public void Remove(Product productIn)
        {
            _products.DeleteOne(product => product.Id == productIn.Id);
        }

        public void Remove(string id)
        {
            _products.DeleteOne(product => product.Id == id);
        }
    }
}
