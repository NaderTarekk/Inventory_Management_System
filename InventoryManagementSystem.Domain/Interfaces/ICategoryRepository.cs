using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllAsync();
        Task CreateAsync(string name);
        Task<Category?> GetByIdAsync(int id);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
        Task<List<Product>> GetProductsByCategoryId(int id);
    }
}
