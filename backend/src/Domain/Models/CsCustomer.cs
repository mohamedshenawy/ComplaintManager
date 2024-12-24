using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CsCustomer
{
    public string Mobile { get; set; } = null!;

    public int CustomerId { get; set; }

    public string Home { get; set; } = null!;

    public string AName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Remark { get; set; } = null!;

    public string Center { get; set; } = null!;

    public short CityId { get; set; }

    public virtual GovernCity City { get; set; } = null!;

    public virtual ICollection<CsVisit> CsVisits { get; set; } = new List<CsVisit>();
}
