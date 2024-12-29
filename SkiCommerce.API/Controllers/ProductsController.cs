using Microsoft.AspNetCore.Mvc;
using SkiCommerce.Core.Entities;
using SkiCommerce.Core.Interfaces;
using SkiCommerce.Core.Specifications;

namespace SkiCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IGenericRepository<Product> repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery]ProductSpecParams specParams)
        {
            var spec = new ProductSpecification(specParams);

            var products = await repo.ListAsync(spec);

            return Ok(products);
        }

        [HttpGet("{id:int}")] // api/products/2
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.Add(product);

            if (await repo.SaveAllAsync())
            {
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }

            return BadRequest("Problem creating product!");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (product.Id != id || !ProductExists(id))
            {
                return BadRequest("Cannot update this product!");
            }

            repo.Update(product);

            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }
             
            return BadRequest("Problem updating the product!");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            repo.Remove(product);

            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem deleting the product!");
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            // TODO: Implement this GetBrands function
            return Ok();
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            // TODO: Implement this GetTypes function
            return Ok();
        }

        private bool ProductExists(int id)
        {
            return repo.Exists(id);
        }   

    }
}