using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CsCall
{
    public DateOnly IssueDate { get; set; }

    public int CustomerId { get; set; }

    public string? EName { get; set; }

    public virtual CsCustomer Customer { get; set; } = null!;
}
