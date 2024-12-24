using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Visit
{
    public record VisitManagerDTO
    (
        int ID,
        int Fees,
        DateOnly? VisitDate,
        DateOnly CallDate,
        string WorkDone,
        string? EmployeeName
        );
}
