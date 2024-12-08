using Microsoft.EntityFrameworkCore;
using SkiCommerce.Core.Entities;
using SkiCommerce.Core.Interfaces;

namespace SkiCommerce.Infrastructure.Data
{
    public class ProductRepository(StoreContext context) : IProductRepository
    {

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await context.Products.ToListAsync();
        }

        public bool ProductExists(int id)
        {
            return context.Products.Any(product => product.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void UpdateProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
        }

    }
}