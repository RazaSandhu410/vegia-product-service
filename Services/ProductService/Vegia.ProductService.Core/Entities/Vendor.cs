using System;
using System.Collections.Generic;

namespace Vegia.ProductService.Core.Entities;

public partial class Vendor
{
    public long VendorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual ICollection<ProductVendor> ProductVendors { get; set; } = new List<ProductVendor>();
}

