using System.Linq.Expressions;

namespace Nowadays.Core.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class // Repository Pattern simplifies CRUD operations
{

    Task<T> GetByIdAsync(int id);
    Task<T> GetWithWhereAsync(Expression<Func<T, bool>> filter);
    IQueryable<T> GetAll();
    //Task<IEnumerable<T>> GetWhereListAsync(Expression<Func<T, bool>> filter);
    Task InsertAsync(T entity);
    Task Delete(T entity);
    Task<int> UpdateAsync(T entity);

}
