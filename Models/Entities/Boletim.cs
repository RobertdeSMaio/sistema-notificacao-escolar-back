using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaNotificacaoEscolarBack.Models.Entities
{
    public class Boletim
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public string Materia { get; set; }

        // 1° Bimestre
        public decimal? Nota1 { get; set; }
        public int? Falta1 { get; set; }

        // 2° Bimestre
        public decimal? Nota2 { get; set; }
        public int? Falta2 { get; set; }

        // 3° Bimestre
        public decimal? Nota3 { get; set; }
        public int? Falta3 { get; set; }

        // 4° Bimestre
        public decimal? Nota4 { get; set; }
        public int? Falta4 { get; set; }

        // Final
        public decimal? NotaFinal { get; set; }
        public int? FaltaFinal { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}