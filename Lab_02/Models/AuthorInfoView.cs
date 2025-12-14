using System;
using System.Collections.Generic;

namespace Lab_02.Models;

public partial class AuthorInfoView
{
    public string FullName { get; set; } = null!;

    public string Age { get; set; } = null!;

    public int? NumberOfTitles { get; set; }

    public double ValueOfStock { get; set; }
}
