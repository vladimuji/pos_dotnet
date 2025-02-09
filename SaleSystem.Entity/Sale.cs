using System;
using System.Collections.Generic;

namespace SaleSystem.Entity;

public partial class Sale
{
    public int IdSale { get; set; }

    public string? SaleNumber { get; set; }

    public int? IdSaleDocType { get; set; }

    public int? IdUserAccount { get; set; }

    public string? ClientDoc { get; set; }

    public string? ClientName { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? TotalTax { get; set; }

    public decimal? Total { get; set; }

    public DateTime? RegisterDate { get; set; }

    public virtual SaleDocType? IdSaleDocTypeNavigation { get; set; }

    public virtual UserAccount? IdUserAccountNavigation { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
