using System;
using System.Collections.Generic;

namespace Vegia.ProductService.Core.Entities;

public partial class ProductVendor
{
    public long ProductVendorId { get; set; }

    public long ProductId { get; set; }

    public long VendorId { get; set; }

    public decimal? Price { get; set; }

    public int? StockQuantity { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Vendor Vendor { get; set; } = null!;
}

