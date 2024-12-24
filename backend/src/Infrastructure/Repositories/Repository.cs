using Application.DTO.Visit;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        #region Retrive 
        public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id) ?? throw new NullReferenceException();

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> conditions)
        {
            return await _dbSet.Where(conditions).ToListAsync();
        }
        #endregion

        #region Post 
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        #endregion
    }
}
