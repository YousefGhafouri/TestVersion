using Dapper;
using System.Collections.Generic;
using Updater.Entities;
//using Microsoft.EntityFrameworkCore;

namespace Updater.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        //IEnumerable<TEntity> IETable { get; }
        //IQueryable<TEntity> Table { get; }
        //IQueryable<TEntity> TableNoTracking { get; }

        TEntity Add(DynamicParameters param);
        void Delete(object id);
        void Update(DynamicParameters param);
        TEntity GetById(object id);
        List<TEntity> Get(params object[] param);
    }
    public interface IRangeRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        void AddRange(IEnumerable<TEntity> entities, bool saveNow = true);
        void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true);
        void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true);
    }
    //public interface IRepository<TEntity> where TEntity : class, IEntity
    //{
    //    DbSet<TEntity> Entities { get; }
    //    IEnumerable<TEntity> IETable { get; }
    //    IQueryable<TEntity> Table { get; }
    //    IQueryable<TEntity> TableNoTracking { get; }

    //    void Add(TEntity entity, bool saveNow = true);
    //    //Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    //    void AddRange(IEnumerable<TEntity> entities, bool saveNow = true);
    //    //Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
    //    void Attach(TEntity entity);
    //    void Delete(TEntity entity, bool saveNow = true);
    //    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    //    void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true);
    //    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
    //    void Detach(TEntity entity);
    //    TEntity GetById(params object[] ids);
    //    Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
    //    void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, ICollection<TProperty>>> collectionProperty) where TProperty : class;
    //    Task LoadCollectionAsync<TProperty>(TEntity entity, Expression<Func<TEntity, ICollection<TProperty>>> collectionProperty, CancellationToken cancellationToken) where TProperty : class;
    //    void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty) where TProperty : class;
    //    Task LoadReferenceAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty, CancellationToken cancellationToken) where TProperty : class;
    //    void Update(TEntity entity, bool saveNow = true);
    //    //Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    //    void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true);
    //    //Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
    //}
}