using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate,bool tracking = true);

        IList<T> GetList(Expression<Func<T, bool>>? predicate = null,bool tracking = true);


        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
