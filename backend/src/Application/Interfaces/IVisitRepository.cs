using Application.DTO.Visit;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IVisitRepository : IRepository<CsVisit>
    {
        Task<List<VisitManagerDTO>> GetVisitsByCustomerIdAsync(int CustomerId);
    }
}
