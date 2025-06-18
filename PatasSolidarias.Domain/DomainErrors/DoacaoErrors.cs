namespace PatasSolidarias.Domain.DomainErrors;

public static class DoacaoErrors
{
    public static string MetodoPagamentoVazio = "Metodo de Pagamento não pode ser vazio";
    public static string ValorMenorQueOuIgualZero = "Valor deve ser maior que 0";
    public static string DataInvalid = "Data de doação é obrigatória";
    public static string DoadorNaoExiste = "Doador fornecido não foi encontrado";
    public static string CampanhaNaoExiste = "Campanha fornecida não foi encontrada";
}