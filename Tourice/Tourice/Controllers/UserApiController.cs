using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tourice.Controllers
{
    [Route("api/[controller]"), Authorize(Roles = "User")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        [HttpGet("user")]
        public IActionResult UserLogedIn()
        {
            try
            {
                return Ok("Welcome User");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
