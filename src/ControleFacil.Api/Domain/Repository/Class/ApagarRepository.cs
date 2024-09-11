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
    public class ApagarRepository : IApagarRepository
    {
        private readonly ApplicationContex _contex;

        public ApagarRepository(ApplicationContex contex)
        {
            _contex = contex;
        }

        #region Add
        public async Task<Apagar> Add(Apagar entidade)
        {
           await _contex.Apagar.AddAsync(entidade);
           await _contex.SaveChangesAsync();
           return entidade;
        }
        #endregion

        #region Delete
        public async Task Delete(Apagar entidade)
        {
            entidade.DataInativacao = DateTime.Now.ToShortDateString();
            await Update(entidade);
        }
        #endregion

        #region Obter
        public async Task<IEnumerable<Apagar>> Obter(long idUser)
        {
            return await _contex.Apagar.OrderBy(a => a.ID).ToListAsync();
        }
        #endregion
        
        #region Obter id
        public async Task<Apagar?> Obter(long id, long idUser)
        {
           return await _contex.Apagar.Where(a => a.ID == id && a.IdUser == idUser).FirstOrDefaultAsync()
           ?? throw new Exception("Entidade não encontrada!");
        }
        #endregion

        #region Obter idUser
        public async Task<IEnumerable<Apagar>> ObterUsuarioId(long IdUser)
        {
            return await _contex.Apagar.Where(a => a.IdUser == IdUser)
            .OrderBy(a => a.ID).ToListAsync();
        }
        #endregion

        #region Update
        public async Task<Apagar> Update(Apagar entidade)
        {
            var apagar = await _contex.Apagar.Where(a => a.ID == entidade.ID).FirstOrDefaultAsync() 
            ?? throw new Exception("Enitade não encontrada!");

            _contex.Entry(apagar).CurrentValues.SetValues(entidade);
            _contex.Update<Apagar>(apagar);
            await _contex.SaveChangesAsync();

            return apagar;
        }
        #endregion
    }
}