namespace SistemaEscolar.Models.DTOs
{
    public record UserCreateDto(string Name, string Email, string Password);
    public record UserResponseDto(int Id, string Name, string Email);
}