using CharismaShop.Model;
using Microsoft.EntityFrameworkCore;

namespace CharismaShop.Repository
{
    public interface IRepository<T>  where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> AddAsync(T entity);
        Task<int> SaveChangesAsync();
        Task<int> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
    }
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        readonly DbContext _context;
        DbSet<T> DbSet => _context.Set<T>();
        public BaseRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IQueryable<T> GetAll()
        {
            return DbSet.Select(a => a);
        }

        public async Task<T> AddAsync(T entity)
        {
            var a = await DbSet.AddAsync(entity);
            await SaveChangesAsync();
            return a.Entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var newObject = _context.Update(entity).Entity;
            await SaveChangesAsync();
            return newObject;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = DbSet.SingleOrDefault(a => a.Id == id);
            if (entity == null)
                throw new Exception("Entity Not Found");
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}