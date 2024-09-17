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
    public class AreceberRepository : IAreceberRepository
    {
        private readonly ApplicationContex _contex;

        public AreceberRepository(ApplicationContex contex)
        {
            _contex = contex;
        }

        #region Add
        public async Task<Areceber> Add(Areceber entidade)
        {
           await _contex.Areceber.AddAsync(entidade);
           await _contex.SaveChangesAsync();
           return entidade;
        }
        #endregion

        #region Delete
        public async Task Delete(Areceber entidade)
        {
            entidade.DataInativacao = DateTime.Now.ToShortDateString();
            await Update(entidade);
        }
        #endregion

        #region Obter
        public async Task<IEnumerable<Areceber>> Obter(long idUser)
        {
            return await _contex.Areceber.OrderBy(a => a.ID).ToListAsync();
        }
        #endregion
        
        #region Obter id
        public async Task<Areceber?> Obter(long id, long idUser)
        {
           return await _contex.Areceber.Where(a => a.ID == id && a.IdUser == idUser).FirstOrDefaultAsync()
           ?? throw new Exception("Entidade não encontrada!");
        }
        #endregion

        #region Obter idUser
        public async Task<IEnumerable<Areceber>> ObterUsuarioId(long IdUser)
        {
            return await _contex.Areceber.Where(a => a.IdUser == IdUser)
            .OrderBy(a => a.ID).ToListAsync();
        }
        #endregion

        #region Update
        public async Task<Areceber> Update(Areceber entidade)
        {
            var Areceber = await _contex.Areceber.Where(a => a.ID == entidade.ID).FirstOrDefaultAsync() 
            ?? throw new Exception("Enitade não encontrada!");

            _contex.Entry(Areceber).CurrentValues.SetValues(entidade);
            _contex.Update<Areceber>(Areceber);
            await _contex.SaveChangesAsync();

            return Areceber;
        }
        #endregion
    }
}