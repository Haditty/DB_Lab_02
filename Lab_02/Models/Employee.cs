using System;
using System.Collections.Generic;

namespace Lab_02.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public int? WorkPlaceId { get; set; }

    public double? Salary { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Store? WorkPlace { get; set; }
}
