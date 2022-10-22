using Inv_Task.Core.InterFace;
using Inv_Task.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.EF.Reposetory
{
    public class ItemRepository:BaseRepository<Items>, IItemRepository
    {
        private readonly ApplicationDbContext _Context;
        public ItemRepository(ApplicationDbContext context):base(context)
        {
            _Context = context;
        }

    }
}
