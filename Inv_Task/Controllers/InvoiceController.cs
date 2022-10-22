using AutoMapper;
using Inv_Task.Core;
using Inv_Task.Core.Model;
using Inv_Task.Core.ViewModel;
using Inv_Task.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Inv_Task.Controllers
{
    [Route("api/Invoice/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        private readonly IUnitOfWork _UOW;

        public InvoiceController(IUnitOfWork UOW)
        {
            this._UOW = UOW;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            try
            {
                var InvMaster = await _UOW.InvMaster_Repo.GetAllInvoicesasync();

                return Ok(_UOW.InvMaster_Repo.GetInvoicesDTO(InvMaster));


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetInvoicebyId(int Id)
        {
            try
            {
                var InvMaster = await _UOW.InvMaster_Repo.GetInvoiceByIdasync(Id);

                return Ok(_UOW.InvMaster_Repo.GetInvoicesDTO(InvMaster));

            
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetInvoicebyCode(int Code)
        {
            try
            {
                var InvMaster = await _UOW.InvMaster_Repo.GetInvoiceByCodeAsync(Code);

                return Ok(_UOW.InvMaster_Repo.GetInvoicesDTO(InvMaster));


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetMaxCode()
        {
            try
            {
                return Ok(await _UOW.InvMaster_Repo.MaxCode());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Inv_Master_ViewModel Model)
        {
            try
            {
                Inv_Master master = new Inv_Master();
                List<Inv_Details> Details = new List<Inv_Details>();

                if (Model != null)
                {

                    var jsonItems = JsonSerializer.Serialize(Model.Inv_Details);
                    Details.AddRange(JsonSerializer.Deserialize<Inv_Details[]>(jsonItems));

                    master.Code = await _UOW.InvMaster_Repo.MaxCode();
                    master.InvoiceDate = Model.invoiceDate;
                    master.Customer_Id = Model.customer_Id;
                    master.CreationDate = DateTime.Now;
                    master.Inv_Details = Details;

                }

                var AddMaster = await _UOW.InvMaster_Repo.Add(master);

                int countObj  = await _UOW.SaveChangesAsync();


                if (countObj > 0)
                    return Ok("Created Successfully");
                else
                    return BadRequest();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateInvoice([FromBody] Inv_Master_ViewModel Model)
        {
            try
            {

                if (Model == null)
                {
                    return BadRequest();
                }


                //Get Master
                var master = await _UOW.InvMaster_Repo.GetByIdAsync((int)Model.id);

                List<Inv_Details> Details = new List<Inv_Details>();

                if (master != null)
                {
                    
                    master.InvoiceDate = Model.invoiceDate;
                    master.Customer_Id = Model.customer_Id;
                }

                await _UOW.SaveChangesAsync();

                //RemoveLastDetail
                var GetDetails = await _UOW.InvDetail_Repo.GetDetalByMasterIdAsync(master.ID);

                if (GetDetails != null)
                {
                    GetDetails.ForEach(s => s.IsDeleted = true);
                }

                await _UOW.SaveChangesAsync();

                //Add NewDetail
                var jsonItems = JsonSerializer.Serialize(Model.Inv_Details);

                Details.AddRange(JsonSerializer.Deserialize<Inv_Details[]>(jsonItems));
                Details.ForEach(s => s.Inv_Master_Id =master.ID);
                Details.ForEach(s => s.CreationDate = DateTime.Now);


                await _UOW.InvDetail_Repo.AddRange(Details);

                await _UOW.SaveChangesAsync();

                return Ok("Created Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInvoice(int Id)
        {
            try
            {
                var GetInvoice = await _UOW.InvMaster_Repo.GetByIdAsync(Id);

                GetInvoice.IsDeleted = true;

               await _UOW.SaveChangesAsync();

                return Ok("Deleted Successfully");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
