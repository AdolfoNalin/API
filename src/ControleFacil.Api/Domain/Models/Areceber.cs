using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Contract.Usuario;
using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.Damain.Models
{
    public class Areceber : Titulos
    {
        [Required(ErrorMessage = "O campo de ValorAreceber é obrigatório")]
        public float ValorRecebido { get; set; }
        public string? DataRecebimento { get; set; } = String.Empty;
    }
}