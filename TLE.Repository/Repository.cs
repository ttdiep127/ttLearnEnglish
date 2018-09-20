using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLE.Entities.DataContext;
using TLE.Entities.Models.EntityModels;
using TLE.Entities.Repositories;

namespace TLE.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TLEContext _context = null;
        public DbSet<TEntity> Entities => _context.Set<TEntity>();

        public DbContext DbContext => _context;

        public Repository(TLEContext context)
        {
            _context = context;
        }

        public void Delete(object id)
        {
            var entity = Entities.Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);

        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
        }

        public TEntity Find(params object[] keyValues)
        {
            return Entities.Find(keyValues);
        }

        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await Entities.FindAsync(keyValues);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        public void Update(TEntity entity)
        {
            Entities.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Entities.UpdateRange(entities);
        }
    }
}
