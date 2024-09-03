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
        [Required(ErrorMessage = "Campo de Descrição é obrigatório!")]
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; } = String.Empty;
        public string? Obs {get; set;} = String.Empty;
        [Required]
        public DateTime DataCadastro { get; set; }
        public DateTime? DataInativacao { get; set; }
    }
}