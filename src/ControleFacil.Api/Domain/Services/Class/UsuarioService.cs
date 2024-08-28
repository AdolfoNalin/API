using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Execution;
using ControleFacil.Api.Contract.Usuario;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interface;
using ControleFacil.Api.Damain.Services.Interface;
using FluentValidation.Validators;
using Humanizer.Bytes;
using Microsoft.VisualBasic;

namespace ControleFacil.Api.Damain.Services.Class
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _userRepository = usuarioRepository;
            _mapper = mapper;
        }

        public Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuario)
        {
            throw new NotImplementedException();
        }

        #region Inativar
        public async Task Inativar(long id, long idUser)
        {
            var usuario = await _userRepository.Obter(id) ?? throw new ArgumentException("Usuário não encontrado!");
            await _userRepository.Delete(_mapper.Map<Usuario>(usuario));
        }
        #endregion

        #region Insert
        public async Task<UsuarioResponseContract> Insert(UsuarioRequestContract entidade, long idUser)
        {
            var usuario = _mapper.Map<Usuario>(entidade);
            usuario.Password = GerarHashSenha(entidade.Password);
            usuario.DataCadastro = DateTime.Now;
            usuario =  await _userRepository.Add(usuario);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }
        #endregion

        #region  Obter email
        public async Task<UsuarioResponseContract> Obter(string email)
        {
            var usuario = await _userRepository.Obter(email) ?? throw new ArgumentNullException("Email incorreto!");
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }
        #endregion

        #region Obter
        public async Task<IEnumerable<UsuarioResponseContract>> Obter()
        {
            var usuario = await _userRepository.Obter();
            return usuario.Select(usuario => _mapper.Map<UsuarioResponseContract>(usuario));
        }
        #endregion

        #region Obter Id
        public async Task<UsuarioResponseContract> Obter(long id, long idUser)
        {
            var usuario = await _userRepository.Obter(id);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }
        #endregion

        #region Update
        public async Task<UsuarioResponseContract> Update(long id, UsuarioRequestContract entidade, long idUser)
        {
            _ = _userRepository.Obter(id) ?? throw new ArgumentException("Usuário não encontrado");
            var usuario = _mapper.Map<Usuario>(entidade);
            usuario.ID = id;
            usuario.Password = GerarHashSenha(entidade.Password);
            usuario = await _userRepository.Update(usuario);
            return _mapper.Map<UsuarioResponseContract>(usuario);
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
                hashSenha = BitConverter.ToString(byteSenHash).Replace("-",".").ToLower();
            };

            return hashSenha;
        }
        #endregion
    }
}