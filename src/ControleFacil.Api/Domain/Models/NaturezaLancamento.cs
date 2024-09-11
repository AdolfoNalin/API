using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Contract.Usuario;

namespace ControleFacil.Api.Damain.Models
{
    public class NaturezaLancamento
    {
        [Key]
        public long ID { get; set; }
        public long IdUser { get; set; }
        public Usuario Usuario { get; set; }
        [Required(ErrorMessage = "Campo de Descrição é obrigatório!")]
        public string Descricao { get; set; } = String.Empty;
        public string? Obs {get; set;} = String.Empty;
        [Required]
        public string DataCadastro { get; set; }
        public string? DataInativacao { get; set; } = String.Empty;
    }
}