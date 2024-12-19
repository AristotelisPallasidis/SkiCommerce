using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiCommerce.Core.Entities;
using SkiCommerce.Core.Interfaces;
using SkiCommerce.Infrastructure.Data;

namespace SkiCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IGenericRepository<Product> repo) : ControllerBase
    {
        /// <summary>
        /// In this function, we are returning a list of products from the database.
        /// </summary>
        /// <returns>The List of Prodcuts</returns>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort)
        {
            return Ok(await repo.ListAllAsync());
        }

        /// <summary>
        /// This function returns a product from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// [HttpGet("{id:int}")] // api/products/2
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// This functuon creates a product in the database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This function updates a product in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ProductExists(int id)
        {
            return repo.Exists(id);
        }   

    }
}