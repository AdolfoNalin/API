using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Contract.Usuario
{
    public class UsuarioLoginRequestContract
    {
        public string Email{ get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    } 
}