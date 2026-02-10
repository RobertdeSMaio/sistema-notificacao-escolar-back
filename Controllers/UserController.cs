[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _userService.ListarTodos());

    [HttpPost]
    public async Task<IActionResult> Post(UserCreateDto dto)
    {
        await _userService.CriarUsuario(dto);
        return Ok(new { message = "Usuário matriculado com sucesso!" });
    }
}