using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.health_clinic.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "Data e horário da consulta é obrigatório!")]
        public string? DatetimeConsulta { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição para prontuário da consulta é obrigatória!")]
        public string? DescricaoConsulta { get; set; }

        //ref tabela Clinica = FK
        [Required(ErrorMessage = "Informe a clínica relacionada a consulta!")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

        //ref tabela Paciente = FK
        [Required(ErrorMessage = "Informe o paciente relacionado a consulta!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //ref tabela Medico = FK
        [Required(ErrorMessage = "Informe o médico relacionado a consulta!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }
    }
}
