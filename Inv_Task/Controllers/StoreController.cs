using Inv_Task.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inv_Task.Controllers
{
    [Route("api/Store/[Action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IUnitOfWork _UOW;
        public StoreController(IUnitOfWork UOW)
        {
            this._UOW = UOW;
        }


        [HttpGet]

        public async Task<IActionResult> GetStores()
        {
            try
            {

                return Ok(await _UOW.Store_Repo.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

    }
}
