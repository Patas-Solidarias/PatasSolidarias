using Microsoft.EntityFrameworkCore;
using PatasSolidaras.Infra.Contexts;
using PatasSolidarias.Domain.Entities.Campanha;
using PatasSolidarias.Domain.Interfaces.Repositories;

namespace PatasSolidaras.Infra.Repositories;

public class CampanhaRepository(ApplicationDbContext context) : BaseRepository<Campanha>(context), ICampanhaRepository
{
    public async Task<IEnumerable<Campanha>> SearchCampanhas(string value)
    {
        return await context
            .Campanhas
            .Where(c => c.Descricao.Contains(value)
                || c.Titulo.Contains(value))
            .ToListAsync();
    }
}