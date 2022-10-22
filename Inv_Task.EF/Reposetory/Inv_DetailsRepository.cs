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
    public class Inv_DetailsRepository :BaseRepository<Inv_Details>, IInv_DetailsRepository
    {
        private ApplicationDbContext _Context;

        public Inv_DetailsRepository(ApplicationDbContext context):base(context)
        {
            _Context = context; 
        }

        public async Task<List<Inv_Details>> GetDetalByMasterIdAsync(int Id)
        {
            return await _Context.Inv_Details.Where(s => s.Inv_Master_Id == Id).ToListAsync();
        }
    }
}
