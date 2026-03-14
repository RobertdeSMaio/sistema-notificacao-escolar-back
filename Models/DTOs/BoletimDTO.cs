namespace SistemaNotificacaoEscolarBack.Models.DTOs
{
    public class BoletimRequest
    {
        public Guid StudentId { get; set; }
        public string Materia { get; set; }
        public decimal? Nota1 { get; set; }
        public int? Falta1 { get; set; }
        public decimal? Nota2 { get; set; }
        public int? Falta2 { get; set; }
        public decimal? Nota3 { get; set; }
        public int? Falta3 { get; set; }
        public decimal? Nota4 { get; set; }
        public int? Falta4 { get; set; }
        public decimal? NotaFinal { get; set; }
        public int? FaltaFinal { get; set; }
    }
}