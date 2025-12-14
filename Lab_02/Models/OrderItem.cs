using System;
using System.Collections.Generic;

namespace Lab_02.Models;

public partial class OrderItem
{
    public int OrderNumber { get; set; }

    public long ItemIsbn { get; set; }

    public int Amount { get; set; }

    public virtual Book ItemIsbnNavigation { get; set; } = null!;

    public virtual Order OrderNumberNavigation { get; set; } = null!;
}
