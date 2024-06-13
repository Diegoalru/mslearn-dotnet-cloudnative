using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Endpoints;
using Products.Metrics;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddDbContext<ProductDataContext>(options =>
    options.UseSqlite(config.GetConnectionString("ProductsContext") ?? throw new InvalidOperationException("Connection string 'ProductsContext' not found.")));

// Add observability code here
builder.Services.AddObservability("Products", config, ["eShopLite.Products"]);

// Register the metrics service.
builder.Services.AddSingleton<ProductsMetrics>();

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapProductEndpoints();

app.MapObservability();

app.UseStaticFiles();

app.CreateDbIfNotExists();

app.Run();
