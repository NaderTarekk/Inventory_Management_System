using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllAsync();
        Task CreateAsync(Category category);
        Task<Category?> GetByIdAsync(int id);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
