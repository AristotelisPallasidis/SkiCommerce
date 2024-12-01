using System;
using Microsoft.EntityFrameworkCore;
using SkiCommerce.Core.Entities;
using SkiCommerce.Infrastructure.Config;

namespace SkiCommerce.Infrastructure.Data;

public class StoreContext(DbContextOptions options) : DbContext(options)
{
    // Database Entitites
    public required DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
    }
}
