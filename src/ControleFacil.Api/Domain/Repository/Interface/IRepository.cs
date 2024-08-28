using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Damain.Repository.Interface
{
    public interface IRepository<T, I> where T : class
    {
        Task<IEnumerable<T>> Obter();
        Task<T?> Obter(I id);
        Task<T> Add(T entidade);
        Task<T> Update (T entidade);
        Task Delete(T entidade);
    }
}