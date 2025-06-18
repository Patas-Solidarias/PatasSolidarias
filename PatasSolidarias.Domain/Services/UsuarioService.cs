using System.Threading.Tasks;
using PatasSolidarias.Domain.DomainErrors;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Entities.Doacoes;
using PatasSolidarias.Domain.Interfaces.Repositories;
using PatasSolidarias.Domain.Interfaces.Services;
using PatasSolidarias.Domain.Services.Requests;

namespace PatasSolidarias.Domain.Services;

public class UsuarioService : BaseService<Usuario>, IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    public UsuarioService(IUsuarioRepository repository) : base(repository)
    {
        _repository = repository;
    }
    
    public override async Task<Usuario> AddAsync(Usuario entity)
    {
        if (string.IsNullOrWhiteSpace(entity.Email))
            throw new DomainException(UsuarioErrors.EmailVazio, nameof(entity.Email));
        
        if (string.IsNullOrWhiteSpace(entity.Nome))
            throw new DomainException(UsuarioErrors.NomeVazio, nameof(entity.Nome));
        
        if (string.IsNullOrWhiteSpace(entity.Senha))
            throw new DomainException(UsuarioErrors.SenhaVazia, nameof(entity.Senha));

        if (string.IsNullOrEmpty(entity.Descricao))
            throw new DomainException(UsuarioErrors.DescricaoVazia, nameof(entity.Descricao));

        var usuarioExistente = GetAll().Any(p => p.Email == entity.Email);
        if (usuarioExistente)
            throw new DomainException(UsuarioErrors.EmailExistente, nameof(entity.Email));

        return await base.AddAsync(entity);
    }

    public async Task<Doacao> AddDonation(AddDonationRequest request)
    {
        ValidateRequest();

        var userFromDatabase = await _repository.GetByIdAsync(request.IdDoador);

        if (userFromDatabase is null)
            throw new DomainException(DoacaoErrors.DoadorNaoExiste, nameof(request.IdDoador));

        var campaingFromDatabase = await _repository.GetCampanhaById(request.IdCampanha);

        if (campaingFromDatabase is null)
            throw new DomainException(DoacaoErrors.CampanhaNaoExiste, nameof(request.IdCampanha));

        var donation = BuildDonation();
        _repository.AddDonation(donation);

        userFromDatabase.AddDonation(donation);

        await _repository.SaveChangesAsync();

        return donation;

        void ValidateRequest()
        {
            if (string.IsNullOrWhiteSpace(request.MetodoPagamento))
                throw new DomainException(DoacaoErrors.MetodoPagamentoVazio, nameof(request.MetodoPagamento));

            if (0 >= request.Valor)
                throw new DomainException(DoacaoErrors.ValorMenorQueOuIgualZero, nameof(request.Valor));

            if (request.Data == DateTime.MinValue)
                throw new DomainException(DoacaoErrors.DataInvalid, nameof(request.Data));
        }

        Doacao BuildDonation() => new(request.Data, request.Valor, request.MetodoPagamento, request.IdCampanha);
    }

    public async Task<IEnumerable<Doacao>> GetAllUserDonations(int userId)
    {
        return await _repository.GetAllUserDonations(userId);
    }

    public Usuario? GetByEmail(string requestEmail)
    {
        if (string.IsNullOrWhiteSpace(requestEmail))
            throw new DomainException(UsuarioErrors.EmailVazio, nameof(requestEmail));

        var retorno = GetAll().FirstOrDefault(p => p.Email == requestEmail);
        return retorno;
    }
}