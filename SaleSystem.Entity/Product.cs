using System;
using System.Collections.Generic;

namespace SaleSystem.Entity;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? BarCode { get; set; }

    public string? Brand { get; set; }

    public string? Description { get; set; }

    public int? IdCategory { get; set; }

    public int? Stock { get; set; }

    public string? ImgUrl { get; set; }

    public string? ImgName { get; set; }

    public decimal? Price { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegisterDate { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }
}
