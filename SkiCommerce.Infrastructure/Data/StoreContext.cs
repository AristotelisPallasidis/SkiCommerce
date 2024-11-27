using System;
using Microsoft.EntityFrameworkCore;
using SkiCommerce.Core.Entities;

namespace SkiCommerce.Infrastructure.Data;

public class StoreContext(DbContextOptions options) : DbContext(options)
{
    // Database Entity Tables - Convention based
    public DbSet<Product> Products { get; set; }

}
