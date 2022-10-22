using Inv_Task.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inv_Task.Controllers
{
    [Route("api/Item/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IUnitOfWork _UOW;
        public ItemController(IUnitOfWork UOW)
        {
            this._UOW = UOW;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                return Ok(await _UOW.Item_Repo.GetAll());
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
        }

    }
}
