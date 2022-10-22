using Inv_Task.Core.Model;
using Inv_Task.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core.InterFace
{
    public interface IInv_MasterRepository : IBaseRepository<Inv_Master>
    {
        Task<int> MaxCode();
        Task<List<Inv_Master>> GetAllInvoicesasync();
        Task<List<Inv_Master>> GetInvoiceByIdasync(int Id);
        Task<List<Inv_Master>> GetInvoiceByCodeAsync(int Code);
        List<Inv_MasterDTO> GetInvoicesDTO(List<Inv_Master> model);




    }
}
