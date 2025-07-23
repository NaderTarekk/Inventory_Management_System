using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using InventoryManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryDbContext _ctx;
        public ProductRepository(InventoryDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(Product product)
        {
            await _ctx.TbProducts.AddAsync(product);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _ctx.TbProducts.FindAsync(id);
            _ctx.TbProducts.Remove(product);
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync() => await _ctx.TbProducts.ToListAsync();

        public async Task<Product?> GetByIdAsync(Guid id) => await _ctx.TbProducts.FindAsync(id);

        public async Task UpdateAsync(Product product)
        {
            _ctx.TbProducts.Update(product);
            await _ctx.SaveChangesAsync();
        }
    }
}
