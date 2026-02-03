[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _repo;
    private readonly AuthService _authService;

    public AuthController(IUserRepository repo, AuthService authService)
    {
        _repo = repo;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var users = await _repo.GetAllAsync();
        var user = users.FirstOrDefault(u => u.Email == login.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
            return Unauthorized("E-mail ou senha inválidos.");

        var token = _authService.GerarToken(user);
        return Ok(new { token });
    }
}