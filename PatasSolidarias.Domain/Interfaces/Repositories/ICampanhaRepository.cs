using PatasSolidarias.Domain.Entities.Campanha;

namespace PatasSolidarias.Domain.Interfaces.Repositories;

public interface ICampanhaRepository: IBaseRepository<Campanha>
{
    Task<IEnumerable<Campanha>> SearchCampanhas(string value);
}