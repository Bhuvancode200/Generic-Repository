using Microsoft.EntityFrameworkCore;
using Generic_Repository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generic_Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _myDbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext ?? throw new ArgumentNullException(nameof(myDbContext));
            _dbSet = _myDbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync() ?? new List<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _dbSet.AddAsync(entity);
            await _myDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Attach(entity);
            _myDbContext.Entry(entity).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }

            _dbSet.Remove(entity);
            await _myDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity) // ✅ Now matches the interface
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Remove(entity);
            await _myDbContext.SaveChangesAsync();
        }
    }
}
