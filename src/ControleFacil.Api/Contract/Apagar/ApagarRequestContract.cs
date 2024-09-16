using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Contract.Titulos;

namespace ControleFacil.Api.Contract.Apagar
{
    public class ApagarRequestContract : TitulosRequestContract
    {
        public float ValorPago { get; set; }
        public string? DataPagamento { get; set; }
    }
}