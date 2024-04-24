using Gallery.Application.Interfaces.Persistence;

namespace Gallery.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly GalleryDbContext _context;

    public UnitOfWork(GalleryDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync() => await _context
    .SaveChangesAsync();

    public IGenericRepository<T> GetRepository<T>() where T : class => new GenericRepository<T>(_context);
}