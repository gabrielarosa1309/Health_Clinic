﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webApi.health_clinic.Domains
{
    [Table(nameof(TiposUsuario))]
    public class TiposUsuario
    {

        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Título do tipo de usuário é obrigatório!")]
        public string? Titulo { get; set; }

    }
}