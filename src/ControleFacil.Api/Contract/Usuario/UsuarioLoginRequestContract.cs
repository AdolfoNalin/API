using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Contract.Usuario
{
    public class UsuarioLoginRequestContract
    {
        public string Email{ get; set; }
        public string Password { get; set; }
    }
}