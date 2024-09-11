using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Contract.Apagar
{
    public class ApagarRequestContract
    {
        public long IdNL { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }
        public float ValorOriginal { get; set; }
        public float ValorPago { get; set; }
        public string? DataRefencia {get; set;}
        public string DataVencimento { get; set; }
        public string? DataPagamento { get; set; }
    }
}