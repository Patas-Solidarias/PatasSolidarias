namespace PatasSolidarias.Backend.Models;

public class DoacaoRequest
{
    public decimal Valor { get; set; }
    public string MetodoPagamento { get; set; } = string.Empty;
    public int IdDoador { get; set; }
}
