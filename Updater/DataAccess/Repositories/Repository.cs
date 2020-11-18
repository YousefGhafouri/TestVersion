using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TestVersion.Utilities;
using Updater.Entities;

namespace Updater.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private ICommandText _commandText;
        private string _connectionString;
        //public virtual IQueryable<TEntity> Table => Entities;
        //public virtual IEnumerable<TEntity> IETable => Entities;
        //public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public Repository(/*Configuration configuration, */ICommandText commandText)
        {
            _commandText = commandText;
            _connectionString = AppConfig.ConnectionString;
            //_connectionString = ConfigurationManager.OpenExeConfiguration("BAService.exe")
            //                                        .ConnectionStrings
            //                                        .ConnectionStrings["ReportBuilderConnection"]
            //                                        .ConnectionString;
        }

        public TEntity GetById(object id)
        {
            return GetById(id, null);
        }
        public TEntity GetById(object id, IDbTransaction transaction)
        {
            return GetById(id, transaction, null);
        }
        public TEntity GetById(object id, IDbTransaction transaction, int? commandTimeout)
        {
            //var dbArgs = new DynamicParameters(new { Id = id });
            //dbArgs.Add("@Id", id);
            var query = CommandHellper.ExecuteCommand<TEntity>(
                        _connectionString,
                        conn => conn.QuerySingleOrDefault<TEntity>(_commandText.GetById,
                                                                    new { Id = id },
                                                                    transaction,
                                                                    commandTimeout,
                                                                    System.Data.CommandType.StoredProcedure)
                                                                    );

            return query == null ? new TEntity() : query;
        }
        //internal override dynamic Mapping(Person person)
        //{
        //    return new { person.LastName, person.FirstName, person.Age };
        //}
        public List<TEntity> Get(IDbTransaction transaction, int? commandTimeout, params object[] param)
        {
            if (!param.Any())
                param = null;
            var query = CommandHellper.ExecuteCommand<List<TEntity>>(
                        _connectionString,
                        conn => conn.Query<TEntity>(_commandText.Get,
                                                    param,
                                                    transaction,
                                                    true,
                                                    commandTimeout,
                                                    CommandType.StoredProcedure).ToXList<TEntity>()
                        );
            return query == null ? new List<TEntity>() : query;
        }
        public List<TEntity> Get(IDbTransaction transaction, params object[] param)
        {
            return Get(transaction, null, param);
        }
        public List<TEntity> Get(int? commandTimeout, params object[] param)
        {
            return Get(null, commandTimeout, param);
        }
        public List<TEntity> Get(params object[] param)
        {
            return Get(null, null, param);
        }

        public virtual TEntity Add(DynamicParameters parameters)
        {
            var result = CommandHellper.ExecuteCommand(
                                                       _connectionString,
                                                       conn => conn.QuerySingleOrDefault<TEntity>(
                                                        _commandText.Add,
                                                        parameters,
                                                        null,
                                                        null,
                                                        CommandType.StoredProcedure)
                                                      );
            return result;
        }

        public virtual void Update(DynamicParameters param)
        {
            CommandHellper.ExecuteCommand(
                                           _connectionString,
                                           conn => conn.Execute(_commandText.Update,
                                                                param,
                                                                null,
                                                                null,
                                                                CommandType.StoredProcedure)
                                         );
        }

        public virtual void UpdateByKey(DynamicParameters param)
        {
            CommandHellper.ExecuteCommand(
                                           _connectionString,
                                           conn => conn.Execute(_commandText.UpdateByKey,
                                                                param,
                                                                null,
                                                                null,
                                                                CommandType.StoredProcedure)
                                         );
        }

        public virtual void Delete(object id)
        {
            CommandHellper.ExecuteCommand(
                                            _connectionString,
                                            conn => conn.Execute(_commandText.Delete,
                                                                new { @Id = id },
                                                                null,
                                                                null,
                                                                CommandType.StoredProcedure)
                                          );
        }

        public string MaxCode()
        {
            string strMaxCode = "1";
            var s = CommandHellper.ExecuteCommand(
                                                       _connectionString,
                                                       conn => conn.Query<string>(
                                                           _commandText.MaxCode)
                                                      );
            string sss = s.ToList<string>()[0];
            return s.ToList()[0].ToString();
        }

    }
    public static class CommandHellper
    {
        public static void ExecuteCommand(string connection, Action<SqlConnection> task)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                task(conn);
            }
        }

        public static T ExecuteCommand<T>(string connection, Func<SqlConnection, T> task)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                return task(conn);
            }
        }

        public static string ExecuteScalar(string connection, Action<SqlConnection> task)
        {
            string result = "1";
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                task(conn);
            }
            return result;
        }
    }
    public interface ICommandText
    {
        string GetById { get; }
        string Get { get; }
        string Add { get; }
        string Update { get; }
        string UpdateByKey { get; }
        string Delete { get; }
        string MaxCode { get; }
    }
    public interface IFilterCommandText : ICommandText
    {
        string GetByFilterId { get; }
    }
    public interface IRangeCommandText : IFilterCommandText
    {
        string AddRange { get; }
        string UpdateRange { get; }
        string DeleteRange { get; }
    }
    //public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    //{
    //    protected readonly AppDbContext DbContext;
    //    public DbSet<TEntity> Entities { get; }
    //    public virtual IQueryable<TEntity> Table => Entities;
    //    public virtual IEnumerable<TEntity> IETable => Entities;
    //    public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

    //    public Repository(AppDbContext dbContext)
    //    {
    //        DbContext = dbContext;
    //        Entities = DbContext.Set<TEntity>(); // City => Cities
    //    }

    //    #region Async Method
    //    public virtual Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
    //    {
    //        return Entities.FindAsync(ids, cancellationToken);
    //    }

    //    //public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
    //    //{
    //    //    Assert.NotNull(entity, nameof(entity));
    //    //    await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
    //    //    if (saveNow)
    //    //        await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    //    //}

    //    //public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
    //    //{
    //    //    Assert.NotNull(entities, nameof(entities));
    //    //    await Entities.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
    //    //    if (saveNow)
    //    //        await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    //    //}

    //    //public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
    //    //{
    //    //    Assert.NotNull(entity, nameof(entity));
    //    //    Entities.Update(entity);
    //    //    if (saveNow)
    //    //        await DbContext.SaveChangesAsync(cancellationToken);
    //    //}

    //    //public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
    //    //{
    //    //    Assert.NotNull(entities, nameof(entities));
    //    //    Entities.UpdateRange(entities);
    //    //    if (saveNow)
    //    //        await DbContext.SaveChangesAsync(cancellationToken);
    //    //}

    //    public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
    //    {
    //        Assert.NotNull(entity, nameof(entity));
    //        Entities.Remove(entity);
    //        if (saveNow)
    //            await DbContext.SaveChangesAsync(cancellationToken);
    //    }

    //    public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
    //    {
    //        Assert.NotNull(entities, nameof(entities));
    //        Entities.RemoveRange(entities);
    //        if (saveNow)
    //            await DbContext.SaveChangesAsync(cancellationToken);
    //    }
    //    #endregion

    //    #region Sync Methods
    //    public virtual TEntity GetById(params object[] ids)
    //    {
    //        return Entities.Find(ids);
    //    }

    //    public virtual void Add(TEntity entity, bool saveNow = true)
    //    {
    //        Assert.NotNull(entity, nameof(entity));
    //        Entities.Add(entity);
    //        if (saveNow)
    //            DbContext.SaveChanges();
    //    }

    //    public virtual void AddRange(IEnumerable<TEntity> entities, bool saveNow = true)
    //    {
    //        Assert.NotNull(entities, nameof(entities));
    //        Entities.AddRange(entities);
    //        if (saveNow)
    //            DbContext.SaveChanges();
    //    }

    //    public virtual void Update(TEntity entity, bool saveNow = true)
    //    {
    //        Assert.NotNull(entity, nameof(entity));
    //        DbContext.Entry(entity).State = EntityState.Modified;
    //        //Entities.Update(entity);
    //        DbContext.SaveChanges();
    //    }

    //    public virtual void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true)
    //    {
    //        Assert.NotNull(entities, nameof(entities));
    //        DbContext.Entry(entities).State = EntityState.Modified;
    //        //Entities.UpdateRange(entities);
    //        if (saveNow)
    //            DbContext.SaveChanges();
    //    }

    //    public virtual void Delete(TEntity entity, bool saveNow = true)
    //    {
    //        Assert.NotNull(entity, nameof(entity));
    //        Entities.Remove(entity);
    //        if (saveNow)
    //            DbContext.SaveChanges();
    //    }

    //    public virtual void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true)
    //    {
    //        Assert.NotNull(entities, nameof(entities));
    //        Entities.RemoveRange(entities);
    //        if (saveNow)
    //            DbContext.SaveChanges();
    //    }
    //    #endregion

    //    #region Attach & Detach
    //    public virtual void Detach(TEntity entity)
    //    {
    //        Assert.NotNull(entity, nameof(entity));
    //        var entry = DbContext.Entry(entity);
    //        if (entry != null)
    //            entry.State = EntityState.Detached;
    //    }

    //    public virtual void Attach(TEntity entity)
    //    {
    //        Assert.NotNull(entity, nameof(entity));
    //        if (DbContext.Entry(entity).State == EntityState.Detached)
    //            Entities.Attach(entity);
    //    }
    //    #endregion

    //    #region Explicit Loading
    //    public virtual async Task LoadCollectionAsync<TProperty>(TEntity entity, Expression<Func<TEntity, ICollection<TProperty>>> collectionProperty, CancellationToken cancellationToken)
    //        where TProperty : class
    //    {
    //        Attach(entity);

    //        var collection = DbContext.Entry(entity).Collection(collectionProperty);
    //        if (!collection.IsLoaded)
    //            await collection.LoadAsync(cancellationToken).ConfigureAwait(false);
    //    }

    //    public virtual void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, ICollection<TProperty>>> collectionProperty)
    //        where TProperty : class
    //    {
    //        Attach(entity);
    //        var collection = DbContext.Entry(entity).Collection(collectionProperty);
    //        if (!collection.IsLoaded)
    //            collection.Load();
    //    }

    //    public virtual async Task LoadReferenceAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty, CancellationToken cancellationToken)
    //        where TProperty : class
    //    {
    //        Attach(entity);
    //        var reference = DbContext.Entry(entity).Reference(referenceProperty);
    //        if (!reference.IsLoaded)
    //            await reference.LoadAsync(cancellationToken).ConfigureAwait(false);
    //    }

    //    public virtual void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty)
    //        where TProperty : class
    //    {
    //        Attach(entity);
    //        var reference = DbContext.Entry(entity).Reference(referenceProperty);
    //        if (!reference.IsLoaded)
    //            reference.Load();
    //    }
    //    #endregion
    //}
}