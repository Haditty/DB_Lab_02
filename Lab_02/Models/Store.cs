using System;
using System.Collections.Generic;

namespace Lab_02.Models;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Adress { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<StockStatus> StockStatuses { get; set; } = new List<StockStatus>();
}
