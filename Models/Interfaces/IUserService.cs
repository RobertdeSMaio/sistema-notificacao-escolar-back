using SistemaNotificacaoEscolarBack.Models.DTOs;

namespace SistemaNotificacaoEscolarBack.Models.Interfaces.IUserService;

public interface IUserService
{
    Task<UserResponse> RegisterAsync(CreateUserRequest request);
    Task<UserResponse?> GetByIdAsync(Guid id);
    Task<UserResponse?> LoginAsync(CreateUserRequest request);
}

public class UserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public DateTime CreatedAt { get; set; }

    public string Role { get; set; }

public UserResponse(Guid id, string name, string email, string cpf, DateTime createdAt, string role)
  {
    Id = id;
    Name = name;
    Email = email;
    CPF = cpf;
    Role = role;
    CreatedAt = createdAt;
    }

}
