using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductsDDD.Application.Interface;
using ProductsDDD.Domain.Entities;
using ProductsDDD.Domain.Interfaces;
using ProductsDDD.Domain.Interfaces.Repositories;

namespace ProductsDDD.API.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppService _productApp;

        public ProductsController(IProductAppService productApp)
        {
            _productApp = productApp;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return _productApp.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public ActionResult<Product> Get(string id)
        {
            var product = _productApp.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _productApp.Create(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id.ToString() }, product);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Product productIn)
        {
            var product = _productApp.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productApp.Update(id, productIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var product = _productApp.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productApp.Remove(product.Id);

            return NoContent();
        }
    }
}
