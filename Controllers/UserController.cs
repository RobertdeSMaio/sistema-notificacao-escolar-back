using Microsoft.AspNetCore.Mvc;
using SistemaNotificacaoEscolarBack.Models.DTOs;
using SistemaNotificacaoEscolarBack.Models.Interfaces.IUserService;

namespace SistemaNotificacaoEscolar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost("register")]
    public async Task<ActionResult<UserResponse>> Create([FromBody] CreateUserRequest request)
    {
        try{
        if (request == null) return BadRequest(new { message = "Dados de registro inválidos" });

        var user = await _userService.RegisterAsync(request);
        
        if (user == null) return BadRequest(new { message = "E-mail já registrado" });

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }
    catch (Exception ex)
    {
        return StatusCode(500, new { message = ex.Message, inner = ex.InnerException?.Message });
    }
}

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] CreateUserRequest request)
    {
        var response = await _userService.LoginAsync(request);

        if (response == null)
        {
            return Unauthorized(new { message = "E-mail ou senha inválidos" });
        }

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserResponse>> GetById(Guid id)
    {
        var user = await _userService.GetByIdAsync(id);
        return user is not null ? Ok(user) : NotFound();
    }
}