namespace PatasSolidarias.Domain.Entities.Doacoes;

public sealed class Doacao {
    public int Id { get; private set; }
    public DateOnly Data { get; private set; }
    public decimal Valor { get; private set; }
    public string MetodoPagamento { get; private set; } = string.Empty;
    public int IdDoador { get; private set; }
    public int IdCampanha { get; private set; }

    private Doacao() { }

    public Doacao(DateOnly data, decimal valor, string metodoPagamento, int idDoador, int idCampanha) {
        Data = data;
        Valor = valor;
        MetodoPagamento = metodoPagamento;
        IdDoador = idDoador;
        IdCampanha = idCampanha;
    }
}