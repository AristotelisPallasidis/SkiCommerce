using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiCommerce.Core.Entities;
using SkiCommerce.Infrastructure.Data;

namespace SkiCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext context;

        public ProductsController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }
    }
}