using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using InventoryManagementSystem.Infrastructure.Models;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly InventoryDbContext _ctx;
        public CategoryRepository(InventoryDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(Category category)
        {
            await _ctx.TbCategories.AddAsync(category);
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

        public async Task UpdateAsync(Category category)
        {
            _ctx.TbCategories.Update(category);
            await _ctx.SaveChangesAsync();
        }
    }
}
