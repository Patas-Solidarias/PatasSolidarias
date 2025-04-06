namespace PatasSolidarias.Application.Interfaces;

public interface IBaseApplicationService<TEntity, TModel> where TEntity : class where TModel : class
{
    Task<TModel> AddAsync(TModel entity);
    Task<TModel> UpdateAsync(TModel entity);
    Task<TModel> RemoveAsync(TModel entity);
    Task<TModel> GetByIdAsync(int id);
    IQueryable<TModel> GetAllAsync();
}