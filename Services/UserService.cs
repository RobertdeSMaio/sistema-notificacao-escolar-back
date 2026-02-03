using SistemaEscolar.Models.DTOs;
using SistemaEscolar.Models.Entities;
using SistemaEscolar.Models.Interfaces;

namespace SistemaEscolar.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserResponseDto>> ListarTodos()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserResponseDto(u.Id, u.Name, u.Email));
        }

        public async Task CriarUsuario(UserCreateDto dto)
        {
            // Aqui você poderia validar se o email já existe
            var user = new User 
            { 
                Name = dto.Name, 
                Email = dto.Email, 
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password) // Segurança!
            };

            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();
        }
    }
}