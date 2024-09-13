namespace CleanArchitecture.Core.Interfaces;
public interface IRepository<TEntity> where TEntity : class
{
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask<TEntity?> ReadAsync(string entityId);
    ValueTask<IEnumerable<TEntity>> ReadAllAsync();
    void Update(TEntity entity);
    void DeleteAsync(TEntity entity);

    int SaveChanges();
}
