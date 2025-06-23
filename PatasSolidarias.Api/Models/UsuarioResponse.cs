using PatasSolidarias.Domain.Entities;

namespace PatasSolidarias.Backend.Models;

public class UsuarioResponse
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Nome { get; set; }
    public DateTime CriadoDataHora { get; set; }
    public EUsuarioTipo UsuarioTipoId { get; set; }
    public string? Descricao { get; set; }
}