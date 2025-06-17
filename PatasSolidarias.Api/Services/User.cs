using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PatasSolidarias.Backend.Services
{
    public class User : IUser
    {
        public User(IHttpContextAccessor httpContextAccessor)
        {
            var claims = (httpContextAccessor.HttpContext?.User.Claims);
            Email = claims?.FirstOrDefault(p => p.Type == ClaimTypes.Email)?.Value;
        }

        public string? Email { get; set; }
    }
}
