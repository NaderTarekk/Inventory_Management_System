using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using InventoryManagementSystem.Infrastructure.Models;
using System.Data.Entity;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InventoryDbContext _ctx;
        public UserRepository(InventoryDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task ChangeIsActiveAsync(Guid id, bool activity)
        {
            var user = _ctx.TbUsers.Find(id);
            user.IsActive = activity;
            _ctx.TbUsers.Update(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task CreateAsync(User user)
        {
            var roleId = Guid.Parse("0002ccee-99e5-455a-dc8b-08ddd8fa90fe");
            user.Role = await _ctx.TbUserRoles.FindAsync(roleId);
            await _ctx.TbUsers.AddAsync(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _ctx.TbUsers.FindAsync(id);
            _ctx.TbUsers.Remove(user);
            await _ctx.SaveChangesAsync();
        }

        public List<User> GetAllAsync() => _ctx.TbUsers.ToList();

        public async Task<User?> GetByIdAsync(Guid id) => await _ctx.TbUsers.FindAsync(id);

        public async Task UpdateAsync(User user)
        {
            var actualUser = await _ctx.TbUsers.FindAsync(user.Id);
            actualUser.FirstName = user.FirstName;
            actualUser.LastName = user.LastName;
            actualUser.Email = user.Email;
            actualUser.Password = user.Password;
            actualUser.IsActive = user.IsActive;
            actualUser.UpdatedAt = DateTime.Now;
            _ctx.TbUsers.Update(actualUser);
            await _ctx.SaveChangesAsync();
        }
    }
}
