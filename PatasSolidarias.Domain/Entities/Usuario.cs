using PatasSolidarias.Domain.Entities.Doacoes;

namespace PatasSolidarias.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Nome { get; set; }
    public required string Senha { get; set; }
    public DateTime CriadoDataHora { get; set; } = DateTime.UtcNow;
    public EUsuarioTipo UsuarioTipoId { get; set; }
    public required string Descricao { get; set; }

    public virtual UsuarioTipo? UsuarioTipo { get; set; }
    public ICollection<Doacao> Doacoes { get; private set; } = [];
}