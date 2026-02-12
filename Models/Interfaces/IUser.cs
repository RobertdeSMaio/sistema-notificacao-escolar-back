// Local: Models/Interfaces/IUserRepository.cs

using SistemaNotificacaoEscolarBack.Models.Entities;

namespace SistemaEscolar.Models.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}