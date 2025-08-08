namespace InventoryManagementSystem.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }                      
        public string Name { get; set; } = string.Empty;   
        public string? Description { get; set; }          

        public int Quantity { get; set; }                
        public int RecorderLevel { get; set; }

        public decimal CostPrice { get; set; }            
        public decimal SellingPrice { get; set; }       

        public bool IsActive { get; set; } = true;

        public string? ImageUrl { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        public DateTime? UpdatedAt { get; set; }
    }
}
