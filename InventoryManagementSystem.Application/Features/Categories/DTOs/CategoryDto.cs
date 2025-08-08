using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Features.Categories.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
