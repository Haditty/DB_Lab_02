using System;
using System.Collections.Generic;

namespace Lab_02.Models;

public partial class Publisher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Adress { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
