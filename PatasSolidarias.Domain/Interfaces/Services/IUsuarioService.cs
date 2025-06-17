using PatasSolidarias.Domain.Entities;

namespace PatasSolidarias.Domain.Interfaces.Services;

public interface IUsuarioService : IBaseService<Usuario>
{
    Usuario? GetByEmail(string requestEmail);
}
