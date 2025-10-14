namespace Vegia.ProductService.Core.Entities
{
    public class ProductVendor
    {
        public int Id { get; set; }
        public decimal VendorPrice { get; set; }
        public string? VendorSku { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign keys
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        
        // Navigation properties
        public virtual Product? Product { get; set; }
        public virtual Vendor? Vendor { get; set; }
    }
}
