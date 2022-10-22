using Inv_Task.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inv_Task.Controllers
{
    [Route("api/Customer/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _UOW;
        public CustomerController(IUnitOfWork UOW)
        {
            this._UOW = UOW;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                return Ok(await _UOW.Customer_Repo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

          
        }

    }
}
