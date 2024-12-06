using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SkiCommerce.Core.Interfaces;
using SkiCommerce.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------
// Add services to the container.
// ----------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();

// ----------------------------------------------------
// Configure the HTTP request pipeline.
// ----------------------------------------------------

app.MapControllers();

app.Run();
