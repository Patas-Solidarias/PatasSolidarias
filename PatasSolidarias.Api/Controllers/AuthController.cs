using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PatasSolidarias.Backend.Configurations;
using PatasSolidarias.Backend.Models;
using PatasSolidarias.Backend.Services;
using PatasSolidarias.Domain.DomainErrors;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Interfaces.Services;

namespace PatasSolidarias.Backend.Controllers;

// TODO: Jogar isso aqui tudo na camada de infra // application
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IUserService _userService;
    private readonly IConfiguracao _configuracao;
    private readonly IPasswordHasher<Usuario> _passwordHasher;

    public AuthController(IUsuarioService usuarioService,
        IUserService userService,
        IConfiguracao configuracao,
        IPasswordHasher<Usuario> passwordHasher
    )
    {
        _usuarioService = usuarioService;
        _userService = userService;
        _configuracao = configuracao;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            var usuario = _usuarioService.GetByEmail(request.Email);

            if (usuario == null)
                return Unauthorized(UsuarioErrors.EmailOuSenhaInvalidos);

            var passwordVerificationResult =
                _passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, request.Senha);
            if (passwordVerificationResult != PasswordVerificationResult.Success)
                return Unauthorized(UsuarioErrors.EmailOuSenhaInvalidos);

            var jwtKey = _configuracao.Jwt.Key;
            var jwtIssuer = _configuracao.Jwt.Issuer;
            var jwtAudience = _configuracao.Jwt.Audience;
            var expirationMinutes = _configuracao.Jwt.ExpirationMinutes;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
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
                expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = jwt });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = "Um erro inesperado ocorreu.", Details = exception.Message });
        }
    }
    
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Add([FromBody] Usuario usuario)
    {
        try
        {
            var xHash = _passwordHasher.HashPassword(usuario, usuario.Senha);
            usuario.Senha = xHash;

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
            return StatusCode(500, new { Error = "Um erro inesperado ocorreu.", Details = exception.Message });
        }
    }

    [HttpGet("usuario")]
    [Authorize]
    public Task<IActionResult> Get()
    {
        try
        {
            var email = _userService.Email;
            if (string.IsNullOrEmpty(email))
                return Task.FromResult<IActionResult>(BadRequest(new { Error = UsuarioErrors.UsuarioNaoEncontrado }));

            var usuario = _usuarioService.GetByEmail(email);

            if (usuario == null)
                return Task.FromResult<IActionResult>(NotFound(new { Error = UsuarioErrors.UsuarioNaoEncontrado }));

            var usuarioResponse = new UsuarioResponse
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nome = usuario.Nome,
                UsuarioTipoId = usuario.UsuarioTipoId,
                Descricao = usuario.Descricao,
                CriadoDataHora = usuario.CriadoDataHora
            };

            return Task.FromResult<IActionResult>(Ok(usuarioResponse));
        }
        catch (Exception exception)
        {
            var retorno = StatusCode(500, new { Error = "Um erro inesperado ocorreu.", Details = exception.Message });
            return Task.FromResult<IActionResult>(retorno);
        }
    }
}