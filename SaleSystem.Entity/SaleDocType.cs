using System;
using System.Collections.Generic;

namespace SaleSystem.Entity;

public partial class SaleDocType
{
    public int IdSaleDocType { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegisterDate { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
