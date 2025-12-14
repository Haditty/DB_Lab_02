using System;
using System.Collections.Generic;

namespace Lab_02.Models;

public partial class Book
{
    public long Isbn { get; set; }

    public string Title { get; set; } = null!;

    public string? Language { get; set; }

    public double? Price { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public int PublisherId { get; set; }

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual ICollection<StockStatus> StockStatuses { get; set; } = new List<StockStatus>();
}
