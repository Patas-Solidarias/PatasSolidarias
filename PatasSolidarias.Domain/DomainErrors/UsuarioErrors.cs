namespace PatasSolidarias.Domain.DomainErrors;

public static class UsuarioErrors
{
    public static string EmailVazio = "Email não pode ser vazio";
    public static string NomeVazio = "Nome não pode ser vazio";
    public static string SenhaVazia = "Senha não pode ser vazia";
    public static string DescricaoVazia = "Descrição não pode ser vazia";
    public static string UsuarioNaoEncontrado = "Usuário não encontrado";
    public static string EmailOuSenhaInvalidos = "Email ou senha inválidos";
    public static string EmailExistente = "Já existe um usuário cadastrado com este email";
}