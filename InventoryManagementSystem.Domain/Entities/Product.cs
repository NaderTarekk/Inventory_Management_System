namespace InventoryManagementSystem.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }                       // المعرف الفريد
        public string Name { get; set; } = string.Empty;   // اسم المنتج
        public string? Description { get; set; }           // وصف اختياري
        public string Category { get; set; } = string.Empty; // التصنيف (قسم)

        public int Quantity { get; set; }                  // الكمية المتوفرة
        public int ReorderLevel { get; set; }              // الحد الأدنى قبل التنبيه

        public decimal CostPrice { get; set; }             // سعر التكلفة
        public decimal SellingPrice { get; set; }          // سعر البيع

        public bool IsActive { get; set; } = true;

        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // تاريخ الإضافة
        public DateTime? UpdatedAt { get; set; }
    }
}
