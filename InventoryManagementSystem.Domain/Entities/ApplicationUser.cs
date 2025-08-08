using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
