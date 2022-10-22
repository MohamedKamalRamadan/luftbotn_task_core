using AutoMapper;
using Inv_Task.Core.InterFace;
using Inv_Task.Core.Model;
using Inv_Task.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.EF.Reposetory
{
    public class Inv_MasterRepository : BaseRepository<Inv_Master>, IInv_MasterRepository
    {
        private ApplicationDbContext _Context;

        public readonly IMapper _mapper;

        public Inv_MasterRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _Context = context;
            _mapper = mapper;
      
        }

        public async Task<int> MaxCode()
        {
            return await _Context.Inv_Master.Select(s => s.Code).MaxAsync()+1;
        }

        public async Task<List<Inv_Master>> GetAllInvoicesasync()
        {

            //return await _Context.Inv_Master.Where(s => !s.IsDeleted).Include().ToListAsync();

            return await _Context.Inv_Master.Where(s => !s.IsDeleted).Include(x => x.Customers).Include(x => x.Inv_Details)
                                                                   .ThenInclude(y => y.Items).Select(m => new Inv_Master
                                                                   {
                                                                       ID = m.ID,
                                                                       Code = m.Code,
                                                                       CreationDate = m.CreationDate,
                                                                       Customer_Id = m.Customer_Id,
                                                                       InvoiceDate = m.InvoiceDate,
                                                                       IsDeleted = m.IsDeleted,
                                                                       Customers = m.Customers,
                                                                       Inv_Details = m.Inv_Details.Where(s => !s.IsDeleted).ToList()
                                                                   }).ToListAsync();

        }

        public async Task<List<Inv_Master>> GetInvoiceByIdasync(int Id)
        {


            return await  _Context.Inv_Master.Where(s => s.ID == Id).Include(x => x.Customers).Include(x => x.Inv_Details)
                            .ThenInclude(y => y.Items).Select(m => new Inv_Master
                            {
                                ID=m.ID,
                                Code=m.Code,
                                CreationDate=m.CreationDate,
                                Customer_Id=m.Customer_Id,
                                InvoiceDate=m.InvoiceDate,
                                IsDeleted=m.IsDeleted,
                                Customers=m.Customers,
                                Inv_Details = m.Inv_Details.Where(s => !s.IsDeleted).ToList()
                            }).ToListAsync();

        }

        public async Task<List<Inv_Master>> GetInvoiceByCodeAsync(int Code)
        {
            return await _Context.Inv_Master.Where(s => s.Code == Code).Include(x => x.Customers).Include(x => x.Inv_Details)
                                                                 .ThenInclude(y => y.Items).Select(m => new Inv_Master
                                                                 {
                                                                     ID = m.ID,
                                                                     Code = m.Code,
                                                                     CreationDate = m.CreationDate,
                                                                     Customer_Id = m.Customer_Id,
                                                                     InvoiceDate = m.InvoiceDate,
                                                                     IsDeleted = m.IsDeleted,
                                                                     Customers = m.Customers,
                                                                     Inv_Details = m.Inv_Details.Where(s => !s.IsDeleted).ToList()
                                                                 }).ToListAsync();
        }


        public List<Inv_MasterDTO> GetInvoicesDTO(List<Inv_Master> model)
        {
            return  _mapper.Map<List<Inv_Master>, List<Inv_MasterDTO>>(model);
        }


    }
}
