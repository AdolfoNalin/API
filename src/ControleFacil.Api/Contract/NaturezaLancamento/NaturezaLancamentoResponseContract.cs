using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Contract.NaturezaLancamento
{
    public class NaturezaLancamentoResponseContract : NaturezaLancamentoRequestContract
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataInativacao { get; set; }
    }
}