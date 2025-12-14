using System;
using System.Collections.Generic;

namespace Lab_02.Models;

public partial class Costumer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
