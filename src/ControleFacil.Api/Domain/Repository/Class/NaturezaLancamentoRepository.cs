using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Domain.Repository.Class
{
    public class NaturezaLancamentoRepository : INaturezaLancamentoRepository
    {
        private readonly ApplicationContex _context;
        public NaturezaLancamentoRepository(ApplicationContex contex)
        {
            _context = contex;
        }

        #region ADD
        public async Task<NaturezaLancamento> Add(NaturezaLancamento entidade)
        {
            await _context.NaturezaLancamento.AddAsync(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }
        #endregion

        #region Delete
        public async Task Delete(NaturezaLancamento entidade)
        {
            entidade.DataInativacao = DateTime.Now;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Obter All
        public async Task<IEnumerable<NaturezaLancamento>> Obter()
        {
            return await _context.NaturezaLancamento.OrderBy(u => u.ID).ToListAsync();
        }
        #endregion

        #region Obter id
        public Task<NaturezaLancamento?> Obter(long id)
        {
            return _context.NaturezaLancamento.Where(nl => nl.ID == id).FirstOrDefaultAsync()??
            throw new ArgumentException("Por favor, digite o código correto!");
        }
        #endregion

        #region ObterUsuarioId
        public async Task<IEnumerable<NaturezaLancamento>> ObterUsuarioId(long IdUser)
        {
            return await _context.NaturezaLancamento.Where(nt => nt.IdUser == IdUser)
            .OrderBy(nf => nf.IdUser)
            .ToListAsync();
        }
        #endregion

        #region Update
        public async Task<NaturezaLancamento> Update(NaturezaLancamento entidade)
        {
            NaturezaLancamento obj =  _context.NaturezaLancamento
            .Where(u => u.ID == entidade.ID)
            .FirstOrDefault();

            _context.Entry(obj).CurrentValues.SetValues(entidade);
            _context.Update<NaturezaLancamento>(obj);

            await _context.SaveChangesAsync();
            return obj;
        }
        #endregion
    }
}