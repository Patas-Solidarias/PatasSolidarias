using PatasSolidarias.Domain.Entities.Campanha;

namespace PatasSolidarias.Domain.Interfaces.Services;

public interface ICampanhaService: IBaseService<Campanha>
{
    Task<bool> AddDoacaoAsync(int campanhaId, decimal valor, string metodoPagamento, int idDoador);
}