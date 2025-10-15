using System;
using System.Collections.Generic;

namespace Vegia.ProductService.Core.Entities;

public partial class Product
{
    public long ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public long? CategoryId { get; set; }

    public bool IsOrganic { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductVendor> ProductVendors { get; set; } = new List<ProductVendor>();
}

