namespace PatasSolidarias.Domain.Interfaces.Services;

public interface IBaseService<TEntity>
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> RemoveAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(int id);
    IQueryable<TEntity> GetAllAsync();    
}