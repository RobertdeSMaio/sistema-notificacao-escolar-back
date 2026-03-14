using SistemaNotificacaoEscolarBack.Models.DTOs;
using SistemaNotificacaoEscolarBack.Models.Entities;

namespace SistemaNotificacaoEscolarBack.Models.Interfaces.IBoletimService
{
    public interface IBoletimService
    {
        Task<bool> SaveAsync(List<BoletimRequest> request);
        Task<List<Boletim>> GetByStudentAsync(Guid studentId);
    }
}