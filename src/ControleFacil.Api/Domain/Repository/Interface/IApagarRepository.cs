using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interface;

namespace ControleFacil.Api.Domain.Repository.Interface
{
    public interface IApagarRepository : IRepository<Apagar, long>
    {
        Task<IEnumerable<Apagar>> ObterUsuarioId(long IdUser);
    }
}