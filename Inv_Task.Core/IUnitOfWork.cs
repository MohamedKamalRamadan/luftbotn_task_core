using AutoMapper;
using Inv_Task.Core.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core
{
    public interface IUnitOfWork: IDisposable
    {
        ICustomerReposetory Customer_Repo { get; }
        IStoreRepository Store_Repo { get; }
        ICategoriesRepository Category_Repo { get; }
        IItemRepository Item_Repo { get; }

        IInv_MasterRepository InvMaster_Repo { get; }

        IInv_DetailsRepository InvDetail_Repo { get; }

        //IMapper mappers { get; }

        Task<int> SaveChangesAsync();
    }
}
