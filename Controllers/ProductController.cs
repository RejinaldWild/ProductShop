using System.Collections.Generic;
using ProductShop.Models;
using ProductShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace ProductShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService Service;
        public ProductController(ProductService service)
        {
            Service = service;
        }

        [HttpGet]
        public ActionResult<ICollection<Product>> GetAll()
        {
            return Ok(Service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {            
            return Ok(Service.Get(id));
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            Service.Add(product); //OnException (override)
            return CreatedAtAction(nameof(Create), product);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            Service.Delete(id);
            return Ok();
        }
    }
}
