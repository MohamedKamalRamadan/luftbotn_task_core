using Inv_Task.Core.InterFace;
using Inv_Task.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.EF.Reposetory
{
    public class StoreRepository:BaseRepository<Stores>,IStoreRepository
    {
        private readonly ApplicationDbContext _Context;

        public StoreRepository(ApplicationDbContext context):base(context)
        {
            this._Context = context;
        }

    }
}
