using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFacil.Api.Contract.Apagar;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Services.Interface;
using ControleFacil.Api.Domain.Repository.Class;
using ControleFacil.Api.Domain.Repository.Interface;

namespace ControleFacil.Api.Domain.Services.Class
{
    public class ApagarService : IService<ApagarRequestContract, ApagarResponseContract, long>
    {
        private readonly IApagarRepository _apagar;
        private readonly IMapper _mapper;

        public ApagarService(IApagarRepository apagar, IMapper mapper)
        {
            _apagar = apagar;
            _mapper = mapper;
        }

        #region  Inativar
        public async Task Inativar(long id, long idUser)
        {
            var apagar = await ObterApagaId(id, idUser) ?? throw new Exception("Entidade não Encontrado!");
            await _apagar.Delete(apagar);
        }
        #endregion

        #region Insert
        public async Task<ApagarResponseContract> Insert(ApagarRequestContract entidade, long idUser)
        {
            var apagar = _mapper.Map<Apagar>(entidade);
            apagar.DataCadastro = DateTime.Now.ToShortDateString();
            apagar.IdUser = idUser;
            apagar = await _apagar.Add(apagar);
            return _mapper.Map<ApagarResponseContract>(apagar);
        }
        #endregion

        #region obter ALL
        public async Task<IEnumerable<ApagarResponseContract>> Obter(long idUser)
        {
            var apagar = await _apagar.ObterUsuarioId(idUser);

            return apagar.Select(titulo => _mapper.Map<ApagarResponseContract>(titulo));
        }
        #endregion

        #region Obter id
        public async Task<ApagarResponseContract> Obter(long id, long idUser)
        {
            var nl = await _apagar.Obter(id, idUser);

            return _mapper.Map<ApagarResponseContract>(nl);
        }
        #endregion

        #region Update
        public async Task<ApagarResponseContract> Update(long id, ApagarRequestContract entidade, long idUser)
        {
            var apagar = await _apagar.Obter(id, idUser);
            var obj = _mapper.Map<Apagar>(entidade);

            obj.IdUser = apagar.IdUser;
            obj.ID = apagar.ID;
            obj.DataCadastro = apagar.DataCadastro;

            obj = await _apagar.Update(obj);
            return _mapper.Map<ApagarResponseContract>(obj);
        }
        #endregion

        #region ObterApagaId
        private async Task<Apagar> ObterApagaId(long id, long idUser)
        {
            var Apagar = await _apagar.Obter(id,idUser);

            if(Apagar is null || Apagar.IdUser != idUser)
            {
                throw new Exception("Não foi encontrada nenhuma apagar pelo id");
            }

            return Apagar;
        }
        #endregion
    }
}