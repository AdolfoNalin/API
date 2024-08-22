using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ControleFacil.Api.Contract.Usuario;
using ControleFacil.Api.Damain.Models;

namespace ControleFacil.Api.Damain.Services.Interface
{
    public interface IUsuarioService : IService<UsuarioRequestContract, UsuarioResponseContract, long>
    {
        Task<UsuarioRequestContract> Autenticar(UsuarioLoginResponseContract usuario);
        Task<UsuarioResponseContract> Obter(string email);
    }
}