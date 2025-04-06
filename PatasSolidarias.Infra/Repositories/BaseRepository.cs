using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Interfaces.Repositories;

namespace PatasSolidaras.Infra.Repositories;

public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity: class
{
    public Task<TEntity> AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> RemoveAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> GetAll()
    {
        // TODO: Adicionar conexão com o banco de dados e retornar os dados
        return Enumerable.Empty<TEntity>().AsQueryable();
    }
}