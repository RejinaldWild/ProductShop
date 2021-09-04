using System.Collections.Generic;
using ProductShop.Models;
using ProductShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {                
                return Ok(Service.Get(id));
            }
            catch(NullReferenceException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                Service.Add(product);
                return CreatedAtAction(nameof(Create), product);
            }
            catch(NullReferenceException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Service.Delete(id);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
        }
    }
}
