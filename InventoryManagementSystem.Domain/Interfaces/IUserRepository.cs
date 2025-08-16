using InventoryManagementSystem.Domain.DTOs;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllAsync();
        Task CreateAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task ChangeIsActiveAsync(Guid id, bool activity);
        Task<bool> CheckEmailIsExistAsync(string email);
        Task<string> LoginAsync(LoginUserDto user);
    }
}
