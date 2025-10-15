using System;
using System.Collections.Generic;

namespace Vegia.ProductService.Core.Entities;

public partial class ProductImage
{
    public long ImageId { get; set; }

    public long ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public bool IsPrimary { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual Product Product { get; set; } = null!;
}

