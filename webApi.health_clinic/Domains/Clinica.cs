using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.health_clinic.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome fantasia da clínica é obrigatório!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Razão social da clínica é obrigatória!")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "CNPJ da clínica é obrigatório!")]
        [StringLength(14, ErrorMessage = "Confira os dígitos do CNPJ e os insira corretamente! (Apenas números)")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereço da clínica é obrigatório!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(15)")]
        [Required(ErrorMessage = "Horário de funcionamento da clínica é obrigatório!")]
        public string? HorarioFuncionamento { get; set; }
    }
}
