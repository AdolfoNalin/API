using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFacil.Api.Contract.Areceber;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Services.Interface;
using ControleFacil.Api.Domain.Repository.Class;
using ControleFacil.Api.Domain.Repository.Interface;
using ControleFacil.Api.Exceptions;
using ControleFacil.Api.Migrations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ControleFacil.Api.Domain.Services.Class
{
    public class AreceberService : IService<AreceberRequestContract, AreceberResponseContract, long>
    {
        private readonly IAreceberRepository _areceber;
        private readonly IMapper _mapper;

        public AreceberService(IAreceberRepository Areceber, IMapper mapper)
        {
            _areceber = Areceber;
            _mapper = mapper;
        }

        #region  Inativar
        public async Task Inativar(long id, long idUser)
        {
            var Areceber = await ObterAreceberId(id, idUser) ?? throw new Exception("Entidade não Encontrado!");
            await _areceber.Delete(Areceber);
        }
        #endregion

        #region Insert
        public async Task<AreceberResponseContract> Insert(AreceberRequestContract entidade, long idUser)
        {
            Validate(entidade);

            var areceber = _mapper.Map<Areceber>(entidade);
            areceber.DataCadastro = DateTime.Now.ToShortDateString();
            areceber.IdUser = idUser;
            areceber = await _areceber.Add(areceber);
            return _mapper.Map<AreceberResponseContract>(areceber);
        }
        #endregion

        #region obter ALL
        public async Task<IEnumerable<AreceberResponseContract>> Obter(long idUser)
        {
            var areceber = await _areceber.ObterUsuarioId(idUser);

            return areceber.Select(titulo => _mapper.Map<AreceberResponseContract>(titulo));
        }
        #endregion

        #region Obter id
        public async Task<AreceberResponseContract> Obter(long id, long idUser)
        {
            var nl = await _areceber.Obter(id, idUser);

            return _mapper.Map<AreceberResponseContract>(nl);
        }
        #endregion

        #region Update
        public async Task<AreceberResponseContract> Update(long id, AreceberRequestContract entidade, long idUser)
        {
            var areceber = await ObterAreceberId(id, idUser);

            Validate(entidade);

            if(areceber.ValorOriginal == entidade.ValorRecebido)
            {
                entidade.DataRecebimento = DateTime.Now.ToShortDateString();
            }

            var obj = _mapper.Map<Areceber>(entidade);

            obj.IdUser = areceber.IdUser;
            obj.ID = areceber.ID;
            obj.DataCadastro = areceber.DataCadastro;

            obj = await _areceber.Update(obj);
            return _mapper.Map<AreceberResponseContract>(obj);
        }
        #endregion

        #region ObterAreceberId
        private async Task<Areceber> ObterAreceberId(long id, long idUser)
        {
            var Areceber = await _areceber.Obter(id,idUser);

            if(Areceber is null || Areceber.IdUser != idUser)
            {
                throw new NotFoundExceptions("Não foi encontrada nenhuma Areceber pelo id");
            }

            return Areceber;
        }
        #endregion

        #region Validate 
        private void Validate(AreceberRequestContract entidade)
        {
            if(entidade.ValorOriginal < 0 || entidade.ValorRecebido < 0)
            {
                throw new NotFoundExceptions("Os campos valoresOriginal e valorRecebido não pode ser negativos!");
            }
        }
        #endregion
    }
}