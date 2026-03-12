using System.Runtime.CompilerServices;
using SistemaNotificacaoEscolarBack.Models.DTOs;

namespace SistemaNotificacaoEscolarBack.Models.Interfaces.IUserService;

public interface IUserService
{
    Task<UserResponse> RegisterAsync(CreateUserRequest request);
    Task<UserResponse?> GetByIdAsync(Guid id);
    Task<UserResponse?> LoginAsync(CreateUserRequest request);
    Task<IEnumerable<UserResponse?>> GetAllAsync();
    Task<bool> UpdateAsync(Guid id, UserResponse request);
    Task<bool> DeleteAsync(Guid id);
}

public class UserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Role { get; set; }
    public string Telefone { get; set; }
    public DateTime UpdatedAt { get; set; }

public UserResponse(Guid id, string name, string email, string cpf, DateTime createdAt, DateTime updatedAt, string role, string telefone)
  {
    Id = id;
    Name = name;
    Email = email;
    CPF = cpf;
    Telefone = telefone;
    Role = role;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
    }


}
