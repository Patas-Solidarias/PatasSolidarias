using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Entities.Campanha;
using PatasSolidarias.Domain.Entities.Doacoes;

namespace PatasSolidarias.Domain.Interfaces.Repositories;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<IEnumerable<Doacao>> GetAllUserDonations(int userId);
    Task<Campanha?> GetCampanhaById(int campaignId);
    void AddDonation(Doacao doacao);
}
