using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Gallery.Application.Interfaces.Persistence;

namespace Gallery.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly GalleryDbContext _context;
    private readonly DbSet<T> _set;
    public GenericRepository(GalleryDbContext context)
    {
        _context = context;
        _set = _context.Set<T>();
    }
    public async Task DeleteAsync(object id)
    {
        var entity = await _set.FindAsync(id) ?? throw new Exception("Entity was not found");
        _set.Remove(entity);
    }

    public IQueryable<T> FindAll(IEnumerable<Expression<Func<T, object>>>? includes = null, IEnumerable<Expression<Func<T, bool>>>? filters = null)
    {
        var elements = _set.OfType<T>();
        if (includes != null)
        {
            IEnumerable<Expression<Func<T, object>>> includesArray = includes as Expression<Func<T, object>>[] ?? includes.ToArray();
            if (includesArray.Any())
            {
                elements = includesArray.Aggregate(elements, (current, includeExpression) => current.Include(includeExpression));
            }
        }

        if (filters != null)
        {
            var filtersArray = filters as Expression<Func<T, bool>>[] ?? filters.ToArray();
            if (filtersArray.Any())
            {
                elements = filtersArray.Aggregate(elements, (current, filterExpression) => current.Where(filterExpression));
            }
        }
        return elements;
    }

    public T? Find(IEnumerable<Expression<Func<T, object>>>? includes = null, IEnumerable<Expression<Func<T, bool>>>? filters = null) => FindAll(includes, filters).FirstOrDefault();

    public async Task InsertAsync(T entity)
    {
        await _set.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _set.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}