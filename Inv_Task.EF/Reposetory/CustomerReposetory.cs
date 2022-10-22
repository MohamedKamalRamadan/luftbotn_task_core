using Inv_Task.Core.InterFace;
using Inv_Task.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.EF.Reposetory
{
    public class CustomerReposetory:BaseRepository<Customers> ,ICustomerReposetory
    {

        protected ApplicationDbContext _Context;
        public CustomerReposetory(ApplicationDbContext Context):base(Context)
        {
            this._Context = Context;
        }

    }
}
