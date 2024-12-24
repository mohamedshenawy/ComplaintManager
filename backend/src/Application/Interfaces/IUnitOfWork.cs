using Domain.Models;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompleteAsync();
        IRepository<CsCall> Calls { get; }
        IRepository<CsCustomer> CsCustomers { get; }
        IVisitRepository CsVisits { get; }
        IRepository<Employee> Employees { get; }
        IRepository<GovernCity> GovernCities { get; }
        IRepository<Governorate> Governorates { get; }
    }
}
