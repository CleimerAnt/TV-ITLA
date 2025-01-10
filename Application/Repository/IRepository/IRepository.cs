using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IRepository<T> where T : class 
    {
        Task Add(T entity);
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filtro = null);
        Task<T> GetById(Expression<Func<T, bool>>? filtro = null);
        Task Eliminar(T entity);
    }
    
}
