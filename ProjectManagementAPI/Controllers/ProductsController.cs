using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            repository.SaveProduct(product);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var product = repository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            repository.DeleteProduct(product);
            return NoContent();
        }

        [HttpPut("id")]
        public IActionResult UpdateProduct(int id)
        {
            var product = repository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            repository.UpdateProduct(product);
            return NoContent();
        }

    }
}