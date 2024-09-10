using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Damain.Services.Interface
{
    /// <summary>
    /// Interface generica para criação de serviços do tipo CRUD
    /// </summary>
    /// <typeparam name="RQ">Contrato de Request</typeparam>
    /// <typeparam name="RS">Contrado de Response</typeparam>
    /// <typeparam name="I">Tipo do Id</typeparam>
    public interface IService<RQ, RS, I> where RQ : class
    {
        Task<IEnumerable<RS>> Obter(I idUser);
        Task<RS> Obter(I id, I idUser);
        Task<RS> Insert(RQ entidade, I idUser);
        Task<RS> Update(I id, RQ entidade, I idUser);
        Task Inativar(I id, I idUser);
    }
}