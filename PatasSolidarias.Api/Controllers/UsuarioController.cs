using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Interfaces.Services;
using PatasSolidarias.Domain.Services.Requests;

namespace PatasSolidarias.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public Task<IActionResult> GetAll()
    {
        var retorno = _usuarioService.GetAll();

        return Task.FromResult<IActionResult>(Ok(retorno));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var retorno = await _usuarioService.GetByIdAsync(id);
        return Ok(retorno);
    }

    [HttpPost]
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
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = "Um erro inesperado aconteceu.", Details = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Usuario usuario)
    {
        try
        {
            var retorno = await _usuarioService.UpdateAsync(usuario);
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
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = "Um erro inesperado aconteceu.", Details = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        try
        {
            var retorno = await _usuarioService.RemoveAsync(id);
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
            return StatusCode(500, new { Error = "Um erro inesperado aconteceu.", Details = exception.Message });
        }
    }

    [HttpGet("{id}/doacoes")]
    public async Task<IActionResult> GetAllUserDonations(int id)
    {
        var retorno = await _usuarioService.GetAllUserDonations(id);

        return Ok(retorno);
    }
    
    [HttpPost("{id}/doacoes")]
    public async Task<IActionResult> AddDonation(AddDonationRequest request)
    {
        try
        {
            var retorno = await _usuarioService.AddDonation(request);
            return Ok(retorno);
        }
        catch (DomainException domainException)
        {
            return BadRequest(new { Error = domainException.Message, domainException.Field });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = "Um erro inesperado aconteceu.", Details = ex.Message });
        }
    }
}