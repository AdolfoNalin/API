using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Contract.Usuario;
using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.Damain.Models
{
    public class Apagar : Titulos
    {
        [Required(ErrorMessage = "O campo de ValorApagar é obrigatório")]
        public float ValorPago { get; set; }
        public string? DataPagamento { get; set; } = String.Empty;
    }
}