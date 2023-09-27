using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.health_clinic.Domains
{
    [Table(nameof(Feedback))]
    public class Feedback
    {
        [Key]
        public Guid IdFeedback { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Feedback da consulta é obrigatório!")]
        public string? FeedbackConsulta { get; set; }

        //ref tabela Paciente = FK
        [Required(ErrorMessage = "Informe o paciente relacionado ao feedback!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //ref tabela Consulta = FK
        [Required(ErrorMessage = "Informe a consulta relacionada ao feedback!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
