using System.ComponentModel.DataAnnotations;

namespace webApi.health_clinic.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "CNPJ obrigatório!")]
        [StringLength(14, ErrorMessage = "Confira os dígitos do CPF e os insira corretamente! (Apenas números)")]
        public string? CPF { get; set; }

        [Required(ErrorMessage = "Senha obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 á 20 caracteres")]
        public string? Senha { get; set; }
    }
}
