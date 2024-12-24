using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Governorate
{
    public short GovernId { get; set; }

    public string AName { get; set; } = null!;

    public string Capital { get; set; } = null!;

    public byte GoverId { get; set; }

    public byte RegionId { get; set; }

    public short DayPrice { get; set; }

    public short Expense { get; set; }

    public virtual ICollection<GovernCity> GovernCities { get; set; } = new List<GovernCity>();
}
