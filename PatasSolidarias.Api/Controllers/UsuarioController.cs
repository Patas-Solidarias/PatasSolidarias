using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PatasSolidarias.Application.Interfaces;
using PatasSolidarias.Application.Models;

namespace PatasSolidarias.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController: ControllerBase
{
    private readonly IUsuarioApplicationService _usuarioService;
    
    public UsuarioController(IUsuarioApplicationService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpGet]
    public Task<IActionResult> GetAll()
    {
        var usuarios = _usuarioService.GetAllAsync();
        return Task.FromResult<IActionResult>(Ok(usuarios));
    }
}