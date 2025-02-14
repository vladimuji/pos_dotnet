﻿using System;
using System.Collections.Generic;

namespace SaleSystem.Entity;

public partial class Company
{
    public int IdCompany { get; set; }

    public string? LogoUrl { get; set; }

    public string? LogoName { get; set; }

    public string? DocName { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public decimal? TaxPercentage { get; set; }

    public string? CurrencySymbol { get; set; }
}
