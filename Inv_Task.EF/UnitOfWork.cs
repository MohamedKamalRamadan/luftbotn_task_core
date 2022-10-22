using AutoMapper;
using Inv_Task.Core;
using Inv_Task.Core.InterFace;
using Inv_Task.EF.Reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _Context;
        public readonly IMapper _mappers;
        public ICustomerReposetory Customer_Repo { get; private set; }
        public IStoreRepository Store_Repo { get; private set; }
        public ICategoriesRepository Category_Repo { get; private set; }
        public IItemRepository Item_Repo { get; private set; }

        public IInv_MasterRepository InvMaster_Repo { get; private set; }
        public IInv_DetailsRepository InvDetail_Repo { get; private set; }

   

        public UnitOfWork(ApplicationDbContext context, IMapper mappers)
        {
            _Context = context;
            _mappers = mappers;
            this.Customer_Repo = new CustomerReposetory(context);
            this.Store_Repo = new StoreRepository(context);
            this.Category_Repo = new CategoriesRepository(context);
            this.Item_Repo = new ItemRepository(context);
            this.InvMaster_Repo = new Inv_MasterRepository(context, mappers);
            this.InvDetail_Repo = new Inv_DetailsRepository(context);
   
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
