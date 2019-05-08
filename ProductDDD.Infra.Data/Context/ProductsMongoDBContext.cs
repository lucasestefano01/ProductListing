using MongoDB.Driver;
using System;

namespace ProductsDDD.Infra.Data.Context
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
