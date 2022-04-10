using CharismaShop.Model;
using CharismaShop.Repository;

namespace CharismaShop.Services
{
    public interface IServiceBase<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> AddAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<int> SaveChangesAsync();
        Task<T> UpdateAsync(T entity);
    }
    public abstract class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        readonly IRepository<T> Repository;
        public ServiceBase(IServiceProvider serviceProvider)
        {
            Repository = serviceProvider.GetRequiredService<IRepository<T>>();
        }

        public IQueryable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual Task<T> AddAsync(T entity)
        {
            return Repository.AddAsync(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return Repository.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            return await Repository.DeleteAsync(id);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await Repository.UpdateAsync(entity);
        }
    }
}