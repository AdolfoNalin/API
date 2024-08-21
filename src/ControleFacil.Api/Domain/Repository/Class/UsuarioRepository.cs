using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interface;
using ControleFacil.Api.Data;
using ControleFacil.Api.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Damain.Repository.Class
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContex _contexto;
        public UsuarioRepository(ApplicationContex contexto)
        {
            _contexto = contexto;
        }
        
        #region Add
        public async Task<Usuario> Add(Usuario entidade)
        {
            await _contexto.Usuario.AddAsync(entidade);
            await _contexto.SaveChangesAsync();
            return await Obter(entidade.ID);
        }
        #endregion

        #region Delete
        public async Task Delete(Usuario entidade)
        {
           _contexto.Entry(entidade).State = EntityState.Deleted;
           await _contexto.SaveChangesAsync();
        }
        #endregion

        #region Obter Email 
        public async Task<Usuario> Obter(string email)
        {
            return await _contexto.Usuario
            .Where(u => u.Email == email).FirstOrDefaultAsync();
        }
        #endregion
        
        #region Obter All
        public async Task<IEnumerable<Usuario>> Obter()
        {
            return await _contexto.Usuario
            .OrderBy(u => u.ID)
            .ToListAsync();
        }
        #endregion

        #region  Obter ID
        public async Task<Usuario?> Obter(long id)
        {
            return await _contexto.Usuario.Where(u => u.ID == id).FirstOrDefaultAsync();
        }
        #endregion

        #region Update
        public async Task<Usuario> Update(Usuario entidade)
        {
            Usuario obj = await _contexto.Usuario
            .Where(u => u.ID == entidade.ID)
            .FirstOrDefaultAsync();

            _contexto.Entry(obj).CurrentValues.SetValues(entidade);
            _contexto.Update<Usuario>(entidade);

            await _contexto.SaveChangesAsync();
            return obj;
        }
        #endregion
    }
}