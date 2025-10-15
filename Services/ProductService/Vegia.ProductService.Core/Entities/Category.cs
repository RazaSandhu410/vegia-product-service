using System;
using System.Collections.Generic;

namespace Vegia.ProductService.Core.Entities;

public partial class Category
{
    public long CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public long? ParentCategoryId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();

    public virtual Category? ParentCategory { get; set; }
}

