using PatasSolidarias.Domain.DomainErrors;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Interfaces.Repositories;
using PatasSolidarias.Domain.Interfaces.Services;

namespace PatasSolidarias.Domain.Services;

public class UsuarioService: BaseService<Usuario>, IUsuarioService
{
    public UsuarioService(IUsuarioRepository repository) : base(repository)
    {
    }
    
    public override async Task<Usuario> AddAsync(Usuario entity)
    {
        if (string.IsNullOrWhiteSpace(entity.Email))
            throw new DomainException(UsuarioErrors.EmailVazio, nameof(entity.Email));
        
        if (string.IsNullOrWhiteSpace(entity.Nome))
            throw new DomainException(UsuarioErrors.NomeVazio, nameof(entity.Nome));
        
        if (string.IsNullOrWhiteSpace(entity.Senha))
            throw new DomainException(UsuarioErrors.SenhaVazia, nameof(entity.Senha));

        if (string.IsNullOrEmpty(entity.Descricao))
            throw new DomainException(UsuarioErrors.DescricaoVazia, nameof(entity.Descricao));

        var usuarioExistente = GetAll().Any(p => p.Email == entity.Email);
        if (usuarioExistente)
            throw new DomainException(UsuarioErrors.EmailExistente, nameof(entity.Email));

        return await base.AddAsync(entity);
    }

    public Usuario? GetByEmail(string requestEmail)
    {
        if (string.IsNullOrWhiteSpace(requestEmail))
            throw new DomainException(UsuarioErrors.EmailVazio, nameof(requestEmail));

        var retorno = GetAll().FirstOrDefault(p => p.Email == requestEmail);
        return retorno;
    }
}