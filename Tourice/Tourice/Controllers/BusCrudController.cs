using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TouriceDatabases.MapperClass;
using TouriceServices.IServices;
using TouriceServices.Services;

namespace Tourice.Controllers
{
    [Route("api/[controller]"),AllowAnonymous]
    [ApiController]
    public class BusCrudController : ControllerBase
    {
        private readonly IBusServices _service;
        public BusCrudController(IBusServices service)
        {
            _service = service;
            
        }

        [HttpGet("Get-Bus-List")]
        public async Task<IActionResult> GetBusList()
        {
            try
            {
                var result = await _service.GetAllBus();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpPost("Get-Route-Bus")]
        public async Task<IActionResult> GetBusFromId(int id)
        {
            try
            {
                var result = await _service.GetBusFromBusId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }
        [HttpPost("Add-Bus")]
        public async Task<IActionResult> AddBus(Bus busDetail)
        {
            try
            {
                var result = await _service.AddBus(busDetail);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpPost("Remove-Bus")]
        public async Task<IActionResult> RemoveBus(int id)
        {
            try
            {
                var result = await _service.RemoveBus(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }
    }
}
