using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Interfaces.Repositories;
using PatasSolidarias.Domain.Interfaces.Services;

namespace PatasSolidarias.Domain.Services;

public class UsuarioService: BaseService<Usuario>, IUsuarioService
{
    public UsuarioService(IBaseRepository<Usuario> repository) : base(repository)
    {
    }
}