using Microsoft.AspNetCore.Mvc;
using PatasSolidarias.Domain.Entities;
using PatasSolidarias.Domain.Interfaces.Services;

namespace PatasSolidarias.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController: ControllerBase
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

        var xTeste = retorno.ToList();
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
        var retorno = await _usuarioService.AddAsync(usuario);
        return Ok(retorno);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Usuario usuario)
    {
        var retorno = await _usuarioService.UpdateAsync(usuario);
        return Ok(retorno);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var retorno = await _usuarioService.RemoveAsync(id);
        return Ok(retorno);
    }
}