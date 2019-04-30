using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Models
{
    public class ProductsMongoDBContext
    {
        public IMongoDatabase Database { get; }

        public ProductsMongoDBContext(MongoClient mongoClient)
        {
            try
            {
                Database = mongoClient.GetDatabase("Products"); 
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel conectar-se ao servidor", ex);
            }
        }
    }

}
