using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using InventoryManagementSystem.Infrastructure.Models;
using System.Data.Entity;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly InventoryDbContext _ctx;
        public CategoryRepository(InventoryDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(string name)
        {
            var obj = new Category { Name = name };
            await _ctx.TbCategories.AddAsync(obj);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _ctx.TbCategories.FindAsync(id);
            _ctx.TbCategories.Remove(category);
            await _ctx.SaveChangesAsync();
        }


        public List<Category> GetAllAsync()
        {
            var result = _ctx.TbCategories.ToList();
            return result;
        }

        public async Task<Category?> GetByIdAsync(int id) => await _ctx.TbCategories.FindAsync(id);

        public async Task<List<Product>> GetProductsByCategoryId(int id)
        {
            var result = _ctx.TbProducts.Where(p => p.CategoryId == id).ToList();
            return result;
        }

        public async Task UpdateAsync(Category category)
        {
            _ctx.TbCategories.Update(category);
            await _ctx.SaveChangesAsync();
        }
    }
}
