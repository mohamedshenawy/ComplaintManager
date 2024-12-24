using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CsVisit
{
    public int VisitId { get; set; }

    public byte RegionId { get; set; }

    public DateOnly IssueDate { get; set; }

    public DateOnly? VisitDate { get; set; }

    public int CustomerId { get; set; }

    public string VisitWord { get; set; } = null!;

    public string WorkDone { get; set; } = null!;

    public short Sales { get; set; }

    public short Meal { get; set; }

    public short Expense { get; set; }

    public short Fees { get; set; }

    public int EmployeCode { get; set; }

    public int DataEntry { get; set; }

    public bool Canceled { get; set; }

    public bool Free { get; set; }

    public bool Ended { get; set; }

    public int VisitId1 { get; set; }

    public byte DefectId { get; set; }

    public byte SalesId { get; set; }

    public int Voucher { get; set; }

    public virtual CsCustomer Customer { get; set; } = null!;

    public virtual Employee DataEntryNavigation { get; set; } = null!;
}
