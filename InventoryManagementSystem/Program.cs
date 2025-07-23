using InventoryManagementSystem.Application.Features.Products.Commands.AddProduct;
using InventoryManagementSystem.Application.Mapping;
using InventoryManagementSystem.Domain.Interfaces;
using InventoryManagementSystem.Infrastructure.Models;
using InventoryManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly));
//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
