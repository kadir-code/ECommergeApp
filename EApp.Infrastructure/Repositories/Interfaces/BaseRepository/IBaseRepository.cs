using EApp.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Infrastructure.Repositories.Interfaces.BaseRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task<T> GetDefaultAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);

    }
}
