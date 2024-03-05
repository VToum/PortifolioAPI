using Microsoft.EntityFrameworkCore;
using PortifolioAPI.Data;
using PortifolioAPI.Models;
using PortifolioAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace PortifolioAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ContactMeDataContext _dbContact;
        internal DbSet<T> _dbSet;
        public Repository(ContactMeDataContext dbContact)
        {
            _dbContact = dbContact;
            this._dbSet = _dbContact.Set<T>();
        }
        public async Task CreateContactAsync(T entity)
        {
            await _dbContact.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filtrar = null)
        {
            IQueryable<T> query = _dbSet;
            if (filtrar != null)
            {
                query = query.Where(filtrar);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetIdAsync(Expression<Func<T, bool>> filtrar = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (filtrar != null)
            {
                query = query.Where(filtrar);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContact.SaveChangesAsync();
        }
    }
}
