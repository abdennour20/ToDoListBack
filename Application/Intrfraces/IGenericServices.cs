using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Intrfraces
{
    public  interface IGenericServices<T>  where T : class
    {

        Task<T?> GetAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<bool> PostAsync(T entity);
        Task<T?> PutAsync(int id, T entity);
        Task<bool> RemoveAsync(int  id);
    }
}
