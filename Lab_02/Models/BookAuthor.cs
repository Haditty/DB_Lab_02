using System;
using System.Collections.Generic;

namespace Lab_02.Models;

public partial class BookAuthor
{
    public int? AuthorId { get; set; }

    public long? Isbn { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Book? IsbnNavigation { get; set; }
}
