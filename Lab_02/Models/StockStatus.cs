using System;
using System.Collections.Generic;

namespace Lab_02.Models;

public partial class StockStatus
{
    public int StoreId { get; set; }

    public long BookId { get; set; }

    public int? InStock { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
