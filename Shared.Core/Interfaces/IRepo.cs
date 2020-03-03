using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shared.Core.HelperModels;

namespace Shared.Core.Interfaces
{
    public interface IRepo<TEntity> where TEntity : class, IBaseModel
    {
        TEntity Get(int id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate, bool withDeleted = false);
        Task<TEntity> GetAsyncById(int id, params string[] include);
        IEnumerable<TEntity> Find(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          string includeProperties = "");
        List<TEntity> GetQueryAsync(string sql);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] include);
        Task<List<TEntity>> GetAsyncAsNoTracking(Expression<Func<TEntity, bool>> predicate, params string[] include);

        List<TEntity> GetAll<TProperty>(params Expression<Func<TEntity, TProperty>>[] include);
        List<TEntity> GetAllWhere(Expression<Func<TEntity, bool>> predicate, params string[] include);

        Task<List<TEntity>> GetAllAsync(params string[] include);
        Task<List<TEntity>> GetAllSyncNew(Expression<Func<TEntity, bool>> predicate, bool withDeleted = false);

        Task<PageViewModel<TEntity>> GetPage(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
        );

        Task<List<TEntity>> GetAllWhereAsync(Expression<Func<TEntity, bool>> predicate, params string[] include);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        int Min(Expression<Func<TEntity, int>> predicate, Expression<Func<TEntity, bool>> condition);
        Task<int> MinAsync(Expression<Func<TEntity, int>> predicate, Expression<Func<TEntity, bool>> condition);

        int Max(Expression<Func<TEntity, int>> predicate, Expression<Func<TEntity, bool>> condition);
        Task<TResult> MaxAsync<TResult>(Expression<Func<TEntity, TResult>> predicate);
        TResult MaxWhere<TResult>(Expression<Func<TEntity, TResult>> predicate, Expression<Func<TEntity, bool>> condition);

        double Sum(Expression<Func<TEntity, double>> predicate, Expression<Func<TEntity, bool>> condition, params string[] include);
        Task<double> SumAsync(Expression<Func<TEntity, double>> predicate, Expression<Func<TEntity, bool>> condition, params string[] include);
        TEntity Add(TEntity obj);
        Task<TEntity> AddAsync(TEntity obj);
        Task<IList<TEntity>> AddRangeAsync(IList<TEntity> obj);
        IList<TEntity> AddRange(IList<TEntity> obj);

        TEntity Update(TEntity obj);
        TEntity Update(int id, TEntity obj);
        IList<TEntity> UpdateRange(IList<TEntity> obj);

        Task Delete(object id);
        Task Delete(TEntity obj);
        Task Delete(Expression<Func<TEntity, bool>> predicate);
        Task DeleteAll(List<TEntity> obj);
        Task DeleteAll(IEnumerable<int> obj);
    }
}
