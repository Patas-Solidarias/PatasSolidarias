using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Entities.Doacoes;
using PatasSolidarias.Domain.Services.Requests;

namespace PatasSolidarias.Domain.Interfaces.Services;

public interface IUsuarioService : IBaseService<Usuario>
{
    Usuario? GetByEmail(string requestEmail);
    Task<IEnumerable<Doacao>> GetAllUserDonations(int userId);
    Task<Doacao> AddDonation(AddDonationRequest request);
}
