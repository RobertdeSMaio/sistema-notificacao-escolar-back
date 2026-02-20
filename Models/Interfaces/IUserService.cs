public interface IUserService
{
    Task<UserResponse> RegisterAsync(CreateUserRequest request);
    Task<UserResponse?> GetByIdAsync(Guid id);
}

public class CreateUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}

public class UserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }

public UserResponse(Guid id, string name, string email, string role, DateTime createdAt)
  {
    Id = id;
    Name = name;
    Email = email;
    Role = role;
    CreatedAt = createdAt;
    }

}