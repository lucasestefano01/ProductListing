using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.ServicesContract
{
    public interface IProductService
    {
        List<Product> Get();
     
        Product Get(string id);

        Product Create(Product product);

        void Update(string id, Product productIn);

        void Remove(Product productIn);

        void Remove(string id);
    }
}
