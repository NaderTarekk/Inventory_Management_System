using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task CreateAsync(Product product);
        Task<Product?> GetByIdAsync(Guid id);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
        Task ChangeIsActiveAsync(Guid id, bool activity);
    }
}
