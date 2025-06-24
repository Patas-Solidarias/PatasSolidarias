using PatasSolidarias.Domain.Entities.Campanha;
using PatasSolidarias.Domain.Entities.Doacoes;
using PatasSolidarias.Domain.Erros;
using PatasSolidarias.Domain.Interfaces.Repositories;
using PatasSolidarias.Domain.Interfaces.Services;

namespace PatasSolidarias.Domain.Services;

public class CampanhaService: BaseService<Campanha>, ICampanhaService
{
    private readonly ICampanhaRepository _repository;

    public CampanhaService(ICampanhaRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<bool> AddDoacaoAsync(int campanhaId, decimal valor, string metodoPagamento, int idDoador)
    {
        var campanha = await _repository.GetByIdAsync(campanhaId);
        if (campanha == null)
            throw new DomainException(CampanhaErrors.CampanhaNaoEncontrada, nameof(Campanha.Id));

        var doacao = new Doacao(DateTime.UtcNow, valor, metodoPagamento, campanhaId);
        campanha.Doacoes.Add(doacao);
        campanha.Progresso += valor;
        await _repository.UpdateAsync(campanha);
        return true;
    }
}