using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Contract.NaturezaLancamento
{
    public class NaturezaLancamentoRequestContract
    {
        public string Descricao { get; set; } = String.Empty;
        public string Obs { get; set; } = String.Empty;
    }
}