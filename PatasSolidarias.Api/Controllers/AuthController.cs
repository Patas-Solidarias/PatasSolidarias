using Microsoft.AspNetCore.Authorization;
using PatasSolidarias.Backend.Models;
using PatasSolidarias.Backend.Services;
using PatasSolidarias.Domain.DomainErrors;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace PatasSolidarias.Backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IUser _user;
    private readonly IConfiguration _configuration;

    public AuthController(IUsuarioService usuarioService, IUser user, IConfiguration configuration)
    {
        _usuarioService = usuarioService;
        _user = user;
        _configuration = configuration;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var usuario = _usuarioService.GetByEmail(request.Email);
        if (usuario == null || usuario.Senha != request.Senha)
            return Unauthorized(UsuarioErrors.EmailOuSenhaInvalidos);

        // TODO: melhorar isso aqui
        // implementar o uso de hash para a senha
        var jwtKey = _configuration["Jwt:Key"];
        var jwtIssuer = _configuration["Jwt:Issuer"];
        var jwtAudience = _configuration["Jwt:Audience"];

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, request.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, request.Email)
        };

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: credentials
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return Ok(new { token = jwt });
    }
    
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Add([FromBody] Usuario usuario)
    {
        try
        {
            var retorno = await _usuarioService.AddAsync(usuario);
            return Ok(retorno);
        }
        catch (DomainException domainException)
        {
            return BadRequest(new
            {
                Error = domainException.Message,
                domainException.Field
            });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = "An unexpected error occurred.", Details = exception.Message });
        }
    }

    [HttpGet("usuario")]
    [Authorize]
    public Task<IActionResult> Get()
    {
        try
        {
            var email = _user.Email;
            if (string.IsNullOrEmpty(email))
                return Task.FromResult<IActionResult>(BadRequest(new { Error = UsuarioErrors.UsuarioNaoEncontrado }));

            var usuario = _usuarioService.GetByEmail(email);
            if (usuario == null)
                return Task.FromResult<IActionResult>(NotFound(new { Error = UsuarioErrors.UsuarioNaoEncontrado }));

            return Task.FromResult<IActionResult>(Ok(usuario));
        }
        catch (Exception exception)
        {
            var retorno = StatusCode(500, new { Error = "An unexpected error occurred.", Details = exception.Message });
            return Task.FromResult<IActionResult>(retorno);
        }
    }
}