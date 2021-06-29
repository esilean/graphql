using GraphQL.API.Interfaces;
using GraphQL.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(int id)
        {
            return await _productService.GetById(id);
        }

        [HttpPost]
        public async Task<Product> Post([FromBody] Product product)
        {
            return await _productService.Add(product);
        }

        [HttpPut("{id}")]
        public async Task<Product> Put(int id, [FromBody] Product product)
        {
            return await _productService.Update(id, product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return NoContent();
        }
    }
}
