using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Contract.Apagar
{
    public class ApagarResponseContract : ApagarRequestContract
    {
        public long Id { get; set; }
        public long idUser { get; set; }
        public string DataCadastro { get; set; }
        public string? DataInativacao { get; set; }
    }
}