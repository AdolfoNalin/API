using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Contract.Titulos;

namespace ControleFacil.Api.Contract.Apagar
{
    public class AreceberRequestContract : TitulosRequestContract
    {
        public float ValorRecebido { get; set; }
        public string? DataRecebimento { get; set; }
    }
}