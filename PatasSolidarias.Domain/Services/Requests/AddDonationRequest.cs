namespace PatasSolidarias.Domain.Services.Requests;

public sealed record AddDonationRequest(int IdDoador, int IdCampanha, string MetodoPagamento, decimal Valor, DateTime Data);