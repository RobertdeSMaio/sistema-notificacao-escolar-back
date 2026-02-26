namespace SistemaNotificacaoEscolarBack.Models.DTOs;

public class CreateUserRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    // O CPF não existe na sua entidade User, então o C# o ignora 
    // ou barra a entrada se houver validação estrita.
    public string? Cpf { get; set; }
}