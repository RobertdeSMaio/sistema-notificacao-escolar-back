using Microsoft.AspNetCore.Mvc;
using SistemaNotificacaoEscolarBack.Models.DTOs;
using SistemaNotificacaoEscolarBack.Models.Entities;
using SistemaNotificacaoEscolarBack.Models.Interfaces.IUserService;
using SistemaNotificacaoEscolarBack.Models.Services;

namespace SistemaNotificacaoEscolar.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost("register")]
    public async Task<ActionResult<UserResponse>> Create([FromBody] CreateUserRequest request)
    {
        
        if(request == null) return BadRequest(new { message = "Dados de registro inválidos" });

        try
        {
            var user = await _userService.RegisterAsync(request);
            return Ok(user);
        }catch (Exception ex)
        {
            return Conflict(new { message = ex.Message });
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

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetById(Guid id)
    {
        var user = await _userService.GetByIdAsync(id);
        return user is not null ? Ok(user) : NotFound();
    }
    [HttpGet("UserList")]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UserResponse request)
    {
        var sucesso = await _userService.UpdateAsync(id, request);

        if (!sucesso) return NotFound();

        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var sucesso = await _userService.DeleteAsync(id);

        if (!sucesso) return NotFound(new{message = "Usuário não encontrado."});

        return NoContent();

    }
}