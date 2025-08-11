namespace InventoryManagementSystem.Domain.Entities
{
    public class UserRole
    {
        public Guid? Id { get; set; }
        public string? RoleName { get; set; } = "Customer";
        public List<User>? Users { get; set; }
    }
}
