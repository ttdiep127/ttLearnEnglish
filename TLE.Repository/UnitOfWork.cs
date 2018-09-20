using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using TLE.Entities.DataContext;
using TLE.Entities.Models.EntityModels;
using TLE.Entities.Repositories;
using TLE.Entities.UnitOfWork;
using TLE.Repository.Repositories;

namespace TLE.Repository
{
    class UnitOfWork : IUnitOfWork
    {
        private TLEContext _dataContext;
        private bool _disposed;
        private Dictionary<string, dynamic> _repositories { get; }
        private ObjectContext _objectContext;
        private IDbTransaction _transaction;

        public UnitOfWork()
        {
            _dataContext = new TLEContext();
            _repositories = new Dictionary<string, dynamic>();
        }
        public void BeginTransaction()
        {
            _objectContext = ((IObjectContextAdapter)_dataContext).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
            }
            _transaction = _objectContext.Connection.BeginTransaction();
        }


        public void CommitTransaction()
        {
            _dataContext.SaveChanges();

            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var entityType = typeof(TEntity).Name.ToUpper();

            if (_repositories.ContainsKey(entityType))
                return (IRepository<TEntity>)_repositories[entityType];

            _repositories.Add(entityType, new Repository<TEntity>(_dataContext));

            return (IRepository<TEntity>)_repositories[entityType];
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }

        public int SaveChanges()
        {
            int i = 0;
            i = _dataContext.SaveChanges();

            return i;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}
