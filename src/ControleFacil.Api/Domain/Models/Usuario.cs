using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Contract.Usuario;

namespace ControleFacil.Api.Damain.Models
{
    public class Usuario
    {
        [Key]
        public long ID { get; set; }
        [Required(ErrorMessage = "Campo de Email é obrigatório!")]
        public string Email { get; set; } = String.Empty;
        [Required(ErrorMessage = "Campo Senha é obrigatório!")]
        public string Password {get; set;} = String.Empty;
        [Required]
        public DateTime DataCadastro { get; set; }
        public DateTime? DataInativacao { get; set; }
    }
}