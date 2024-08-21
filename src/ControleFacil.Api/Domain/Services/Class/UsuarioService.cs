using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ControleFacil.Api.Contract.Usuario;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interface;
using ControleFacil.Api.Damain.Services.Interface;
using Humanizer.Bytes;

namespace ControleFacil.Api.Damain.Services.Class
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository ur, IMapper mapper)
        {
            _usuarioRepository = ur;
            _mapper = mapper;
        }

        #region Autenticar
        public Task<UsuarioRequestContract> Autenticar(UsuarioLoginResponseContract usuario)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Inativar
        public Task Inativar(long id, long idUser)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Insert
        public async Task<UsuarioResponseContract> Insert(UsuarioRequestContract entidade, long idUser)
        {
            var usuario = _mapper.Map<Usuario>(entidade);
            usuario.Password = GerarHashSenha(usuario.Password);
            await _usuarioRepository.Add(usuario);

            return _mapper.Map<UsuarioResponseContract>(usuario);
        }
        #endregion

        #region Obter IdUser
        public Task<IEnumerable<UsuarioLoginResponseContract>> Obter(long idUser)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region  Obter id and IdUser
        public Task<UsuarioLoginResponseContract> Obter(long id, long idUser)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public Task<UsuarioLoginResponseContract> Update(long id, UsuarioRequestContract entidade, long idUser)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GerarHashSenha
        private string GerarHashSenha(string senha)
        {
            string hashSenha;
            using(SHA256 pass = SHA256.Create())
            {
                byte[] Bsenha = Encoding.UTF8.GetBytes(senha);
                byte[] byteSenHash = pass.ComputeHash(Bsenha);
                hashSenha = BitConverter.ToString(byteSenHash).ToLower();
            };

            return hashSenha;
        }
        #endregion
    }
}