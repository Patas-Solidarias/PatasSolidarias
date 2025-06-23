namespace PatasSolidarias.Backend.Configurations;

public interface IConfiguracao
{
    ConfiguracoesJwt Jwt { get; set; }
}

public class Configuracao : IConfiguracao
{
    public required ConfiguracoesJwt Jwt { get; set; }
}

public class ConfiguracoesJwt
{
    public required string Key { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public int ExpirationMinutes { get; set; } = 20;
}
