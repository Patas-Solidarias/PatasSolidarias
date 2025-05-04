using Microsoft.EntityFrameworkCore;
using PatasSolidaras.Infra.Contexts;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Erros;
using PatasSolidarias.Domain.Interfaces.Repositories;

namespace PatasSolidaras.Infra.Repositories;

public class BaseRepository<TEntity>(ApplicationDbContext context) : IBaseRepository<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        await SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> RemoveAsync(int entityId)
    {
        var entity = await _dbSet.FindAsync(entityId);
        if (entity == null)
            throw new Exception(DomainErrors.ErroAoExcluirEntidade);

        _dbSet.Remove(entity);
        await SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        var retorno = await _dbSet.FindAsync(id);
        return retorno;
    }

    public IQueryable<TEntity> GetAll()
    {
        var retorno = _dbSet.AsQueryable();
        return retorno;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}