using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Contract.Usuario
{
    public class UsuarioResponseContract : UsuarioLoginRequestContract
    {
        public long Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}