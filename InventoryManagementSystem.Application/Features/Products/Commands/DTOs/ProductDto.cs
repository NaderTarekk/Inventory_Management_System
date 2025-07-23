namespace InventoryManagementSystem.Application.Features.Products.Commands.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }                    
        public string Name { get; set; } = string.Empty;  
        public string? Description { get; set; }         
        public string Category { get; set; } = string.Empty;

        public int Quantity { get; set; }                  
        public int ReorderLevel { get; set; }           

        public decimal CostPrice { get; set; }         
        public decimal SellingPrice { get; set; }         

        public bool IsActive { get; set; } = true;

        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
