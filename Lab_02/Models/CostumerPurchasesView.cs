using System;
using System.Collections.Generic;

namespace Lab_02.Models;

public partial class CostumerPurchasesView
{
    public string FullName { get; set; } = null!;

    public int? NumberOfPurchesedArticles { get; set; }

    public double? TotalSpent { get; set; }

    public string? PurchasedTitles { get; set; }
}
