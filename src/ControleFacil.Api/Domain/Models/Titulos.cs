using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;

namespace ControleFacil.Api.Domain.Models
{
    public abstract class Titulos
    {
         [Key]
        public long ID { get; set; }
        [Required]
        public long IdUser { get; set; }
        public Usuario Usuario { get; set; }
        [Required]
        public long IdNL { get; set; }
        public NaturezaLancamento NaturezaLancamento { get; set; }
        [Required(ErrorMessage = "Campo de Descrição é obrigatório!")]
        public string Descricao { get; set; } = String.Empty;
        public string? Obs {get; set;} = String.Empty;
        [Required(ErrorMessage = "Valor original é obrigatório")]
        public float ValorOriginal { get; set; }
        [Required]
        public string DataCadastro { get; set; }
        [Required(ErrorMessage = "Data de vencimento é obrigatório")]
        public string? DataVencimento { get; set; } = String.Empty;
        public string? DataInativacao { get; set; } = String.Empty;
        public string? DataRefencia { get; set; } = String.Empty;
    }
}