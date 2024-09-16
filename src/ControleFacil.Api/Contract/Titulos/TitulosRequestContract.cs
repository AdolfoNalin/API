using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Contract.Titulos
{
    public abstract class TitulosRequestContract
    {
         public long IdNL { get; set; }
        public string Descricao { get; set; } = String.Empty;
        public string Obs { get; set; } = String.Empty;
        public float ValorOriginal { get; set; }
        public string? DataRefencia {get; set;}
        public string DataVencimento { get; set; } = String.Empty;
        
    }
}