using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interface;

namespace ControleFacil.Api.Domain.Repository.Interface
{
    public interface INaturezaLancamentoRepository : IRepository<NaturezaLancamento, long>
    {
        Task<IEnumerable<NaturezaLancamento>> ObterUsuarioId(long IdUser);
    }
}