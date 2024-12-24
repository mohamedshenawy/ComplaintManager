using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class GovernCity
{
    public short CityId { get; set; }

    public string AName { get; set; } = null!;

    public short GovernId { get; set; }

    public bool Blocked { get; set; }

    public short Price { get; set; }

    public virtual ICollection<CsCustomer> CsCustomers { get; set; } = new List<CsCustomer>();

    public virtual Governorate Govern { get; set; } = null!;
}
