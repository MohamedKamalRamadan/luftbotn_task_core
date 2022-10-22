using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core.InterFace
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T Model);
        Task<IEnumerable<T>> AddRange(IEnumerable<T> Entity);

    }
}
