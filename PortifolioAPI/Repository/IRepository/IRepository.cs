using System.Linq.Expressions;

namespace PortifolioAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filtrar = null);
        Task<T> GetIdAsync(Expression<Func<T, bool>> filtrar = null, bool tracked = true);
        Task CreateContactAsync(T entity);
        Task SaveAsync();
    }
}
