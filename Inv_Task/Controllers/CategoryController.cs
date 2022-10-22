using Inv_Task.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inv_Task.Controllers
{
    [Route("api/Category/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _UOW;
        public CategoryController(IUnitOfWork UOW)
        {
            this._UOW = UOW;
        }

        public async Task<IActionResult> GetCategory()
        {
            try
            {
                return Ok(await _UOW.Category_Repo.GetAll());
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
        }
    }
}
