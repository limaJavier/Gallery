using System.Linq.Expressions;

namespace Gallery.Application.Interfaces.Persistence;

public interface IGenericRepository<T> where T : class
{
    // Queries
    T? Find(IEnumerable<Expression<Func<T, object>>>? includes = null, IEnumerable<Expression<Func<T, bool>>>? filters = null);
    IQueryable<T> FindAll(IEnumerable<Expression<Func<T, object>>>? includes = null, IEnumerable<Expression<Func<T, bool>>>? filters = null);

    // Commands
    void Update(T entity);
    Task InsertAsync(T entity);
    Task DeleteAsync(object id);
}