using Inv_Task.Core.InterFace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.EF.Reposetory
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _Context;

        public BaseRepository(ApplicationDbContext Context)
        {
            this._Context = Context;
        }


        public async Task<T> GetByIdAsync(int Id)
        {
            return await _Context.Set<T>().FindAsync(Id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _Context.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T Model)
        {
           
             await _Context.Set<T>().AddAsync(Model);

            return Model;
        }

        public async Task<IEnumerable<T>> AddRange(IEnumerable<T> Entity)
        {
            await _Context.Set<T>().AddRangeAsync(Entity);
            return Entity;
        }
    }
}
