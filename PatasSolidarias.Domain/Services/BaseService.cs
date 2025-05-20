using PatasSolidarias.Domain.Erros;
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
        var retorno = await _repository.AddAsync(entity);
        return retorno;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var retorno = await _repository.UpdateAsync(entity);
        return retorno;
    }

    public async Task<TEntity> RemoveAsync(int entityId)
    {
        var retorno = await _repository.RemoveAsync(entityId);
        return retorno;
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        var retorno = await _repository.GetByIdAsync(id);
        return retorno;
    }

    public IQueryable<TEntity> GetAll()
    {
        var xReturn = _repository.GetAll();
        return xReturn;
    }
}