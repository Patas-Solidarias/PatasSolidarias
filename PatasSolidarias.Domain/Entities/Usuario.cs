using PatasSolidarias.Domain.Entities.Doacoes;
using System.ComponentModel.DataAnnotations;
using PatasSolidarias.Domain.DomainErrors;

namespace PatasSolidarias.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public required string Email { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public required string Nome { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public required string Senha { get; set; }
    public DateTime CriadoDataHora { get; set; } = DateTime.UtcNow;
    public EUsuarioTipo UsuarioTipoId { get; set; }
    [MaxLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string? Descricao { get; set; }

    public virtual UsuarioTipo? UsuarioTipo { get; set; }
    public ICollection<Doacao> Doacoes { get; private set; } = [];
}