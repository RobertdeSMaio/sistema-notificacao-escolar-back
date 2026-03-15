
namespace SistemaNotificacaoEscolarBack.DTOs
{
    public class EstatisticasResponse
    {
        public int TotalAlunos { get; set; }
        public int Ano { get; set; } = DateTime.UtcNow.Year;
        public double MediaGeral { get; set; }
        public int TotalFaltas { get; set; }
        public int TotalMaterias { get; set; }
        public List<MediaPorMateria> MediasPorMateria { get; set; }
        public List<FaltasPorMateria> FaltasPorMateria { get; set; }
        public List<EvolucaoBimestre> EvolucaoPorBimestre { get; set; }
        public List<RankingAluno> RankingAlunos { get; set; }
    }

    public class MediaPorMateria
    {
        public string Materia { get; set; }
        public double Media { get; set; }
    }

    public class FaltasPorMateria
    {
        public string Materia { get; set; }
        public int TotalFaltas { get; set; }
    }

    public class EvolucaoBimestre
    {
        public string Bimestre { get; set; }
        public double Media { get; set; }
    }

    public class RankingAluno
    {
        public string Aluno { get; set; }
        public double MediaFinal { get; set; }
    }
}