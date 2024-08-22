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
using FluentValidation.Validators;
using Humanizer.Bytes;
using Microsoft.VisualBasic;

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
        public async Task Inativar(long id, long idUser)
        {
            var usuario =  await _usuarioRepository.Obter(id) ?? throw new ArgumentNullException(@"Usuário não encontrado para a inativação! 
            Certifiquece o código ou a existencia dele no banco de dados!");

            await _usuarioRepository.Delete(_mapper.Map<Usuario>(usuario));

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
        public async Task<IEnumerable<UsuarioResponseContract>> Obter(long idUser)
        {
            return await Obter(idUser);
        }
        #endregion

        #region  Obter id and IdUser
        public async Task<UsuarioResponseContract> Obter(long id, long idUser)
        {
            var usuario = await _usuarioRepository.Obter(id);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }
        #endregion 
        
        #region Obter email
        public async Task<UsuarioResponseContract> Obter(string email)
        {
            var usuario = await _usuarioRepository.Obter(email);

            return _mapper.Map<UsuarioResponseContract>(usuario);
        }
        #endregion

        #region Update
        public async Task<UsuarioResponseContract> Update(long id, UsuarioRequestContract entidade, long idUser)
        {
            _= await _usuarioRepository.Obter(id) ?? throw new ArgumentNullException("Usuário não encontrado para a autualização!");

            var usuario = _mapper.Map<Usuario>(entidade);   
            usuario.ID = id;
            usuario.Password = GerarHashSenha(entidade.Password);
            usuario = await _usuarioRepository.Update(usuario);

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
                hashSenha = BitConverter.ToString(byteSenHash).ToLower();
            };

            return hashSenha;
        }

        Task<IEnumerable<UsuarioResponseContract>> IService<UsuarioRequestContract, UsuarioResponseContract, long>.Obter(long idUser)
        {
            throw new NotImplementedException();
        }

        Task<UsuarioResponseContract> IService<UsuarioRequestContract, UsuarioResponseContract, long>.Obter(long id, long idUser)
        {
            throw new NotImplementedException();
        }

        Task<UsuarioResponseContract> IService<UsuarioRequestContract, UsuarioResponseContract, long>.Update(long id, UsuarioRequestContract entidade, long idUser)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}