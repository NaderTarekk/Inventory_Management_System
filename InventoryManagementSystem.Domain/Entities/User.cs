namespace InventoryManagementSystem.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;

        public UserRole? Role { get; set; } = new UserRole();

        public bool? IsActive { get; set; } = true;

        public DateOnly? CreatedAt { get; set; } = new DateOnly();

        public DateTime? UpdatedAt { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}
