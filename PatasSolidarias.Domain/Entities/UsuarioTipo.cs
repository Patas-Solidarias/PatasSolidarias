namespace PatasSolidarias.Domain.Entities;

public class UsuarioTipo
{
    public static UsuarioTipo[] UsuarioTipos =
    [
        new UsuarioTipo { Id = EUsuarioTipo.Doador, Nome = "Doador" },
        new UsuarioTipo { Id = EUsuarioTipo.EmpresaParceira, Nome = "Ajudante" },
        new UsuarioTipo { Id = EUsuarioTipo.Ong, Nome = "ONG" }
    ];

    public EUsuarioTipo Id { get; set; }
    public required string Nome { get; set; }
}