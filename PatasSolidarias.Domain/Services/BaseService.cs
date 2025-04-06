using PatasSolidarias.Domain.Interfaces.Repositories;
using PatasSolidarias.Domain.Interfaces.Services;

namespace PatasSolidarias.Domain.Services;

public class BaseService<TEntity>: IBaseService<TEntity> where TEntity : class
{
    private readonly IBaseRepository<TEntity> _repository;

    public BaseService(IBaseRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var xReturn = await _repository.AddAsync(entity);
        return xReturn;
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        var xReturn = _repository.UpdateAsync(entity);
        return xReturn;
    }

    public Task<TEntity> RemoveAsync(TEntity entity)
    {
        var xReturn = _repository.RemoveAsync(entity);
        return xReturn;
    }

    public Task<TEntity> GetByIdAsync(int id)
    {
        var xReturn = _repository.GetByIdAsync(id);
        return xReturn;
    }

    public IQueryable<TEntity> GetAllAsync()
    {
        var xReturn = _repository.GetAll();
        return xReturn;
    }
}