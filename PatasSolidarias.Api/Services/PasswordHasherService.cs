using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using PatasSolidarias.Domain.Entities;

namespace PatasSolidarias.Backend.Services;

/// <summary>
/// Feito para fins de estudo, usar o do ASP.NET Core Identity em produção.
/// </summary>
public class PasswordHashService : IPasswordHasher<Usuario>
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100000;

    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    public string HashPassword(Usuario user, string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public PasswordVerificationResult VerifyHashedPassword(Usuario user, string hashedPassword, string providedPassword)
    {
        var parts = hashedPassword.Split('-');
        var hash = Convert.FromHexString(parts[0]);
        var salt = Convert.FromHexString(parts[1]);

        var inputHash = Rfc2898DeriveBytes.Pbkdf2(providedPassword, salt, Iterations, Algorithm, HashSize);

        var isMatch = CryptographicOperations.FixedTimeEquals(hash, inputHash);
        var retorno = isMatch ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        return retorno;
    }
}