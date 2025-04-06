using PatasSolidarias.Application.Interfaces;
using PatasSolidarias.Application.Models;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Services;

namespace PatasSolidarias.Application.Services;

public class UsuarioApplicationService(UsuarioService service) : ApplicationServiceBase<Usuario, UsuarioDto>(service), IUsuarioApplicationService
{
    public override Task<UsuarioDto> AddAsync(UsuarioDto entity)
    {
        throw new NotImplementedException();
    }

    public override Task<UsuarioDto> UpdateAsync(UsuarioDto entity)
    {
        throw new NotImplementedException();
    }

    public override Task<UsuarioDto> RemoveAsync(UsuarioDto entity)
    {
        throw new NotImplementedException();
    }

    public override Task<UsuarioDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public override IQueryable<UsuarioDto> GetAllAsync()
    {
        var retorno = service.GetAllAsync().Select(p => new UsuarioDto
            {
               Id = p.Id,
                Email = p.Email
            });

        return retorno;
    }
}