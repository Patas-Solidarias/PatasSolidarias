using PatasSolidaras.Infra.Contexts;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Interfaces.Repositories;

namespace PatasSolidaras.Infra.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext context) : base(context)
    {
    }
}
