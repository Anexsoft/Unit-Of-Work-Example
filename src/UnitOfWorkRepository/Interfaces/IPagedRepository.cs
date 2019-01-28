using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnitOfWorkRepository.Repository;

namespace UnitOfWorkRepository.Repository.Interfaces
{
    public interface IPagedRepository<T> where T : class
    {
        Task<DataCollection<T>> GetPagedAsync(
            int page,
            int take,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        );

        DataCollection<T> GetPaged(
            int page,
            int take,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        );
    }
}
