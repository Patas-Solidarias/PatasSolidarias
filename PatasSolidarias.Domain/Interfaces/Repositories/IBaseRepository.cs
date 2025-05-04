namespace PatasSolidarias.Domain.Interfaces.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> RemoveAsync(int entityId);
    Task<TEntity?> GetByIdAsync(int id);
    IQueryable<TEntity> GetAll();
    Task SaveChangesAsync();
}