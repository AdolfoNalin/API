using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Execution;
using ControleFacil.Api.Contract.Usuario;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interface;
using ControleFacil.Api.Damain.Services.Interface;
using ControleFacil.Api.Domain.Services.Class;
using FluentValidation.Validators;
using Humanizer.Bytes;
using Microsoft.VisualBasic;

namespace ControleFacil.Api.Damain.Services.Class
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, TokenService tokenService)
        {
            _userRepository = usuarioRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        #region Autenticar
        public async Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuarioLogin)
        {
            var usuario = await Obter(usuarioLogin.Email);
            var hashSenha = GerarHashSenha(usuarioLogin.Password);

            if(usuario is null || usuario.Password != hashSenha)
            {
                throw new AuthenticationException("Usuário ou senha inválido!");
            }
            
            return new UsuarioLoginResponseContract{
                Id = usuario.Id,
                Email = usuario.Email,
                Token = _tokenService.Token(_mapper.Map<Usuario>(usuario))
            };
        }
        #endregion

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
        public async Task<IEnumerable<UsuarioResponseContract>> Obter(long idUser)
        {
            var usuario = await _userRepository.Obter(idUser);
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