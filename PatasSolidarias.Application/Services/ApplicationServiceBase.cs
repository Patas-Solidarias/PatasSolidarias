using PatasSolidarias.Application.Interfaces;
using PatasSolidarias.Application.Models;
using PatasSolidarias.Domain.Interfaces.Services;

namespace PatasSolidarias.Application.Services;

public abstract class ApplicationServiceBase<TEntity, TModel>(IBaseService<TEntity> service)
    : IBaseApplicationService<TEntity, TModel>
    where TEntity : class
    where TModel : class
{
    private readonly IBaseService<TEntity> _service = service;
    public abstract Task<TModel> AddAsync(TModel entity);
    public abstract Task<TModel> UpdateAsync(TModel entity);
    public abstract Task<TModel> RemoveAsync(TModel entity);
    public abstract Task<TModel> GetByIdAsync(int id);
    public abstract IQueryable<TModel> GetAllAsync();
}