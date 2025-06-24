using PatasSolidaras.Infra.Contexts;
using PatasSolidarias.Domain.Entities.Campanha;
using PatasSolidarias.Domain.Interfaces.Repositories;

namespace PatasSolidaras.Infra.Repositories;

public class CampanhaRepository(ApplicationDbContext context) : BaseRepository<Campanha>(context), ICampanhaRepository
{
    
}