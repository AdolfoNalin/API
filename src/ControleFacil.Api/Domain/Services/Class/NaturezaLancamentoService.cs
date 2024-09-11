using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFacil.Api.Contract.NaturezaLancamento;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Services.Interface;
using ControleFacil.Api.Domain.Repository.Interface;

namespace ControleFacil.Api.Domain.Services.Class
{
    public class NaturezaLancamentoService : IService<NaturezaLancamentoRequestContract, NaturezaLancamentoResponseContract, long>
    {
        private readonly INaturezaLancamentoRepository _nl;
        private readonly IMapper _mapper;

        public NaturezaLancamentoService(INaturezaLancamentoRepository nl, IMapper mapper)
        {
            _nl = nl;
            _mapper = mapper;
        }

        #region  Inativar
        public async Task Inativar(long id, long idUser)
        {
            var naturezaLancamento = await ObterNaturezaLancamentoId(id, idUser);
            await _nl.Delete(naturezaLancamento);
        }
        #endregion

        #region Insert
        public async Task<NaturezaLancamentoResponseContract> Insert(NaturezaLancamentoRequestContract entidade, long idUser)
        {
            var nl = _mapper.Map<NaturezaLancamento>(entidade);
            nl.DataCadastro = DateTime.Now.ToShortDateString();
            nl.IdUser = idUser;
            nl = await _nl.Add(nl);
            return _mapper.Map<NaturezaLancamentoResponseContract>(nl);
        }
        #endregion

        #region obter ALL
        public async Task<IEnumerable<NaturezaLancamentoResponseContract>> Obter(long idUser)
        {
            var nl = await _nl.ObterUsuarioId(idUser);

            return nl.Select(n => _mapper.Map<NaturezaLancamentoResponseContract>(n));
        }
        #endregion

        #region Obter id
        public async Task<NaturezaLancamentoResponseContract> Obter(long id, long idUser)
        {
            var nl = await ObterNaturezaLancamentoId(id, idUser);

            return _mapper.Map<NaturezaLancamentoResponseContract>(nl);
        }
        #endregion

        #region Update
        public async Task<NaturezaLancamentoResponseContract> Update(long id, NaturezaLancamentoRequestContract entidade, long idUser)
        {
            var nl = await _nl.Obter(id, idUser);
            nl.Descricao = entidade.Descricao;
            nl.Obs = entidade.Obs;
            nl = await _nl.Update(nl);
            return _mapper.Map<NaturezaLancamentoResponseContract>(nl);
        }
        #endregion

        #region ObternaturezaLancamentoId
        private async Task<NaturezaLancamento> ObterNaturezaLancamentoId(long id, long idUser)
        {
            var naturezaLancamento = await _nl.Obter(id,idUser);

            if(naturezaLancamento is null || naturezaLancamento.IdUser != idUser)
            {
                throw new Exception("Não foi encontrada nenhuma natureza lançamento pelo id");
            }

            return naturezaLancamento;
        }
        #endregion
    }
}