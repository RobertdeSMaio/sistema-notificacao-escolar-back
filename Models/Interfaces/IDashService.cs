using SistemaNotificacaoEscolarBack.DTOs;

namespace SistemaNotificacaoEscolarBack.Interfaces.Dash
{
    public interface IDashService
    {
        Task<EstatisticasResponse> GetEstatisticasAsync(string? materia);
    }
}