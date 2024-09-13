using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence;

internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _entity;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _entity = context.Set<TEntity>();
    }


    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        await _entity.AddAsync(entity);

        return entity;
    }

    public async ValueTask<IEnumerable<TEntity>> ReadAllAsync()
       => await _entity.AsNoTracking().ToListAsync();


    public async ValueTask<TEntity?> ReadAsync(string entityId)
       => await _entity.FindAsync(entityId);


    public void Update(TEntity entity)
        => _entity.Attach(entity);


    public void DeleteAsync(TEntity entity)
        => _entity.Remove(entity);


    public int SaveChanges()
        => _context.SaveChanges();

}
