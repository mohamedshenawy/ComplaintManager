using Application.DTO.Visit;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;


public class VisitRepository : Repository<CsVisit>, IVisitRepository
{
    public VisitRepository(DatabaseContext context) : base(context)
    { }

    public async Task<List<VisitManagerDTO>> GetVisitsByCustomerIdAsync(int CustomerId)
    {
        var query = from visit in _context.CsVisits
                    where visit.CustomerId == CustomerId
                    select new
                    {
                        ID = visit.VisitId,
                        Fees = visit.Fees,
                        VisitDate = visit.VisitDate,
                        CallVisit = visit.IssueDate,
                        WorkDone = visit.WorkDone,
                        EmployeeName = (from emp in _context.Employees
                                        where emp.EmployeCode == visit.EmployeCode
                                        select emp.AName).SingleOrDefault()
                    };

        var mappedQuery = query.Select(e =>
        new VisitManagerDTO(e.ID, e.Fees, e.VisitDate, e.CallVisit, e.WorkDone, e.EmployeeName)
        ).ToList();


        return mappedQuery;
    }
}
