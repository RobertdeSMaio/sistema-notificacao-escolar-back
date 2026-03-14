using Microsoft.EntityFrameworkCore;
using SistemaNotificacaoEscolarBack.Data.Context;
using SistemaNotificacaoEscolarBack.Models.DTOs;
using SistemaNotificacaoEscolarBack.Models.Entities;
using SistemaNotificacaoEscolarBack.Models.Interfaces.IBoletimService;

namespace SistemaNotificacaoEscolarBack.Models.Services
{
    public class BoletimService : IBoletimService
    {
        private readonly MyDbContext _context;

        public BoletimService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync(List<BoletimRequest> request)
        {
            foreach (var item in request)
            {
                var existing = await _context.Boletins
                    .FirstOrDefaultAsync(b => b.StudentId == item.StudentId && b.Materia == item.Materia);

                if (existing != null)
                {
                    existing.Nota1 = item.Nota1;
                    existing.Falta1 = item.Falta1;
                    existing.Nota2 = item.Nota2;
                    existing.Falta2 = item.Falta2;
                    existing.Nota3 = item.Nota3;
                    existing.Falta3 = item.Falta3;
                    existing.Nota4 = item.Nota4;
                    existing.Falta4 = item.Falta4;
                    existing.NotaFinal = item.NotaFinal;
                    existing.FaltaFinal = item.FaltaFinal;
                    existing.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    _context.Boletins.Add(new Boletim
                    {
                        StudentId = item.StudentId,
                        Materia = item.Materia,
                        Nota1 = item.Nota1,
                        Falta1 = item.Falta1,
                        Nota2 = item.Nota2,
                        Falta2 = item.Falta2,
                        Nota3 = item.Nota3,
                        Falta3 = item.Falta3,
                        Nota4 = item.Nota4,
                        Falta4 = item.Falta4,
                        NotaFinal = item.NotaFinal,
                        FaltaFinal = item.FaltaFinal,
                    });
                }
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Boletim>> GetByStudentAsync(Guid studentId)
        {
            return await _context.Boletins
                .Where(b => b.StudentId == studentId)
                .OrderBy(b => b.Materia)
                .ToListAsync();
        }
    }
}