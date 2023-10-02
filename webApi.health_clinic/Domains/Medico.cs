using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.health_clinic.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(6)")]
        [Required(ErrorMessage = "CRM do médico é obrigatório!")]
        [StringLength(6, ErrorMessage = "Confira os dígitos do CRM e os insira corretamente! (Apenas números)")]
        public string? CRM { get; set; }

        //ref tabela Especialidade = FK
        [Required(ErrorMessage = "Informe a especialidade do médico!")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        //ref tabela Usuario = FK
        [Required(ErrorMessage = "Informe o usuário relacionado ao médico!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //ref tabela Clinica = FK
        [Required(ErrorMessage = "Informe a clínica do médico!")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
    }
}
