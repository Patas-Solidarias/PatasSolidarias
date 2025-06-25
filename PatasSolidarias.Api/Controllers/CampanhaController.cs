using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatasSolidarias.Backend.Models;
using PatasSolidarias.Domain.Entities.Campanha;
using PatasSolidarias.Domain.Interfaces.Services;

namespace PatasSolidarias.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CampanhaController : ControllerBase
{
    private readonly ICampanhaService _campanhaService;

    public CampanhaController(ICampanhaService campanhaService)
    {
        _campanhaService = campanhaService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var retorno = _campanhaService.GetAll();
        return Ok(retorno);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var retorno = await _campanhaService.GetByIdAsync(id);
        return Ok(retorno);
    }
    
    [HttpGet("search/{value}")]
     public async Task<IActionResult> Search(string value)
     {
         var retorno = await _campanhaService.SearchCampanhas(value);
         return Ok(retorno);
     }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Campanha campanha)
    {
        try
        {
            var retorno = await _campanhaService.AddAsync(campanha);
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
    public async Task<IActionResult> Update([FromBody] Campanha campanha)
    {
        try
        {
            var retorno = await _campanhaService.UpdateAsync(campanha);
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
            var retorno = await _campanhaService.RemoveAsync(id);
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

    [HttpPost("{id}/doacoes")]
    public async Task<IActionResult> AdicionarDoacao(int id, [FromBody] DoacaoRequest request)
    {
        try
        {
            var sucesso = await _campanhaService.AddDoacaoAsync(id,
                request.Valor,
                request.MetodoPagamento,
                request.IdDoador
            );

            if (!sucesso)
                return NotFound(new { Error = "Campanha não encontrada." });

            return Ok(new { Success = true });
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
}
