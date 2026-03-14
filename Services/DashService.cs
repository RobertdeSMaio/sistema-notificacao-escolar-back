using Microsoft.EntityFrameworkCore;
using SistemaNotificacaoEscolarBack.Data.Context;
using SistemaNotificacaoEscolarBack.DTOs;
using SistemaNotificacaoEscolarBack.Interfaces.Dash;

namespace SistemaNotificacaoEscolarBack.Services.Dash
{

    public class DashService : IDashService
    {
        private readonly MyDbContext _context;

        public DashService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<EstatisticasResponse> GetEstatisticasAsync(string? materia)
        {
            var query = _context.Boletins
                .Include(b => b.Student)
                .AsQueryable();

            if (!string.IsNullOrEmpty(materia))
                query = query.Where(b => b.Materia == materia);

            var boletins = await query.ToListAsync();

            if (!boletins.Any())
                return new EstatisticasResponse();

            // KPIs
            var totalAlunos = boletins.Select(b => b.StudentId).Distinct().Count();
            var totalFaltas = boletins.Sum(b =>
                (b.Falta1 ?? 0) + (b.Falta2 ?? 0) +
                (b.Falta3 ?? 0) + (b.Falta4 ?? 0) + (b.FaltaFinal ?? 0));
            var totalMaterias = boletins.Select(b => b.Materia).Distinct().Count();

            var todasNotas = boletins.SelectMany(b => new[] {
                b.Nota1, b.Nota2, b.Nota3, b.Nota4, b.NotaFinal
            }).Where(n => n.HasValue).Select(n => (double)n.Value).ToList();

            var mediaGeral = todasNotas.Any() ? todasNotas.Average() : 0;

            // Média por matéria
            var mediasPorMateria = boletins
                .GroupBy(b => b.Materia)
                .Select(g => new MediaPorMateria
                {
                    Materia = g.Key,
                    Media = g.SelectMany(b => new[] { b.Nota1, b.Nota2, b.Nota3, b.Nota4, b.NotaFinal })
                              .Where(n => n.HasValue)
                              .Select(n => (double)n.Value)
                              .DefaultIfEmpty(0)
                              .Average()
                })
                .OrderBy(m => m.Materia)
                .ToList();

            // Faltas por matéria
            var faltasPorMateria = boletins
                .GroupBy(b => b.Materia)
                .Select(g => new FaltasPorMateria
                {
                    Materia = g.Key,
                    TotalFaltas = g.Sum(b =>
                        (b.Falta1 ?? 0) + (b.Falta2 ?? 0) +
                        (b.Falta3 ?? 0) + (b.Falta4 ?? 0) + (b.FaltaFinal ?? 0))
                })
                .OrderBy(f => f.Materia)
                .ToList();

            // Evolução por bimestre
            var evolucao = new List<EvolucaoBimestre>
            {
                new() { Bimestre = "1° Bim", Media = boletins.Where(b => b.Nota1.HasValue).Select(b => (double)b.Nota1.Value).DefaultIfEmpty(0).Average() },
                new() { Bimestre = "2° Bim", Media = boletins.Where(b => b.Nota2.HasValue).Select(b => (double)b.Nota2.Value).DefaultIfEmpty(0).Average() },
                new() { Bimestre = "3° Bim", Media = boletins.Where(b => b.Nota3.HasValue).Select(b => (double)b.Nota3.Value).DefaultIfEmpty(0).Average() },
                new() { Bimestre = "4° Bim", Media = boletins.Where(b => b.Nota4.HasValue).Select(b => (double)b.Nota4.Value).DefaultIfEmpty(0).Average() },
                new() { Bimestre = "Final",  Media = boletins.Where(b => b.NotaFinal.HasValue).Select(b => (double)b.NotaFinal.Value).DefaultIfEmpty(0).Average() },
            };

            // Ranking de alunos
            var ranking = boletins
                .GroupBy(b => b.Student != null ? b.Student.Name : b.StudentId.ToString())
                .Select(g => new RankingAluno
                {
                    Aluno = g.Key,
                    MediaFinal = g.Where(b => b.NotaFinal.HasValue)
                                  .Select(b => (double)b.NotaFinal.Value)
                                  .DefaultIfEmpty(0)
                                  .Average()
                })
                .OrderByDescending(r => r.MediaFinal)
                .Take(10)
                .ToList();

            return new EstatisticasResponse
            {
                TotalAlunos = totalAlunos,
                MediaGeral = Math.Round(mediaGeral, 1),
                TotalFaltas = totalFaltas,
                TotalMaterias = totalMaterias,
                MediasPorMateria = mediasPorMateria,
                FaltasPorMateria = faltasPorMateria,
                EvolucaoPorBimestre = evolucao,
                RankingAlunos = ranking,
            };
        }
    }
}