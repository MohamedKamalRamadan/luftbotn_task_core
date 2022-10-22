using Inv_Task.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core.InterFace
{
    public interface IInv_DetailsRepository:IBaseRepository<Inv_Details>
    {
        Task<List<Inv_Details>> GetDetalByMasterIdAsync(int Id);
    }
}
