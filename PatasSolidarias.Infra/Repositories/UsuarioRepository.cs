using Microsoft.EntityFrameworkCore;
using PatasSolidaras.Infra.Contexts;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Entities.Campanha;
using PatasSolidarias.Domain.Entities.Doacoes;
using PatasSolidarias.Domain.Interfaces.Repositories;

namespace PatasSolidaras.Infra.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    private readonly ApplicationDbContext _context;
    public UsuarioRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void AddDonation(Doacao doacao) => _context.Doacoes.Add(doacao);

    public async Task<IEnumerable<Doacao>> GetAllUserDonations(int userId)
        => await _context.Doacoes.Where(d => d.IdDoador == userId).ToListAsync();

    public async Task<Campanha?> GetCampanhaById(int campaignId)
        => await _context.Campanhas.FirstOrDefaultAsync(c => c.ID == campaignId);
}
