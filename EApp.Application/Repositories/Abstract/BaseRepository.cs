using EApp.Domain.Entities.Abstract;
using EApp.Infrastructure.Context;
using EApp.Infrastructure.Repositories.Interfaces.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Application.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<T> _table;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task<T> GetDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.FirstOrDefaultAsync(expression);
        }

        public async Task CreateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
