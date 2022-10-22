using Inv_Task.Core.InterFace;
using Inv_Task.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.EF.Reposetory
{
    public class CategoriesRepository:BaseRepository<Categories>, ICategoriesRepository
    {
        private readonly ApplicationDbContext _Context;
        public CategoriesRepository(ApplicationDbContext context):base(context)
        {
            _Context = context; 
        }
    }
}
