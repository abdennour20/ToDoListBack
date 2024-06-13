using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _db;
        public Repository(ApplicationDbContext db )
        {

            _context = db;
            _db = _context.Set<T>();
        }
        public async  Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {

            IQueryable<T> query = _db;

            foreach (var item in includes)
                query = query.Include(item);

            return await query.ToListAsync();
        }

        public  async Task<T?> GetAsync(int id , params Expression<Func<T, object>>[] includes)
        {
           
            IQueryable<T> query = _db;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);

        }
        
        public async Task<bool> PostAsync(T entity)
        {
            await _db.AddAsync(entity)  ;
            return await _context.SaveChangesAsync() >0 ;
        }

        public async Task<T?> PutAsync(int id, T entity)
        {
            var existingEntity = await _db.FindAsync(id);
            if (existingEntity == null)
            {
                return default;
            }

         _context.Entry(existingEntity).CurrentValues.SetValues(entity);
           await _context.SaveChangesAsync() ;

            return existingEntity;


        }

        public async Task<bool> RemoveAsync(int id)
        {
            var entity = await _db.FindAsync(id);
            if (entity == null)
            {
                return false; 
            }

            _context.Set<T>().Remove(entity);

            return await _context.SaveChangesAsync() >0 ;
        }
    }
}
