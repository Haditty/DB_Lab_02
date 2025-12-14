using System;
using System.Collections.Generic;

namespace Lab_02.Models;

public partial class Order
{
    public int OrderNumber { get; set; }

    public int? EmployeeId { get; set; }

    public int CostumerId { get; set; }

    public int StoreCode { get; set; }

    public virtual Costumer Costumer { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual Store StoreCodeNavigation { get; set; } = null!;
}
