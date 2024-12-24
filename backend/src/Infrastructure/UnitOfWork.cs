using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IRepository<CsCall> Calls  => new Repository<CsCall>(_context);

        public IRepository<CsCustomer> CsCustomers => new Repository<CsCustomer>(_context);

        public IRepository<Employee> Employees => new Repository<Employee>(_context);

        public IRepository<GovernCity> GovernCities => new Repository<GovernCity>(_context);
            
        public IRepository<Governorate> Governorates => new Repository<Governorate>(_context);

        IVisitRepository IUnitOfWork.CsVisits => new VisitRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
