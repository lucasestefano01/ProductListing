using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Services
{
    public class ProductService
    {
        // TODO - CRIAR UMA CONTRATO PRA SERVICE
        private readonly IMongoCollection<Product> _products;

        // TODO -ABSTRAIR A CONEXÃO COM O BANCO
        public ProductService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Products"));
            var database = client.GetDatabase("Products");
            _products = database.GetCollection<Product>("Products");
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
