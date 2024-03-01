using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using TouriceDatabases.MapperClass;
using TouriceDatabases.Modals;
using TouriceServices.IServices;

namespace Tourice.Controllers
{
    [Route("api/[controller]")]  //, Authorize(Roles ="Admin")
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _service;
        private readonly IBusServices _busService;
        private IMapper _mapper;
        public AdminController(IAdminServices service, IMapper mapper, IBusServices busService)
        {
            _service = service;
            _mapper = mapper;
            _busService = busService;
        }
        [HttpGet("Admin")]
        public IActionResult AdminLogedIn()
        {
            try
            {
                return Ok("Welcome Admin");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
        [HttpGet("Get-Drivers")]
        public async Task<IActionResult> DriveList()
        {
            try
            {
                var result =  await _service.GetBusDriver();
                return Ok(result);
            }catch(Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpPost("Add-Driver")]
        public async Task< IActionResult> AddDriver(BusDriver busDriverDetail)
        {
            try
            {
                tblBusDriver busDriver = _mapper.Map<tblBusDriver>(busDriverDetail);
                busDriver.UserId = 1003;
                  var result = await _service.AddDriver(busDriver);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }
        [HttpPost("Remove-Driver")]
        public async Task<IActionResult> RemoveDriver(int id)
        {
            try
            {
                var result = await _service.RemoveDriver(id);
                return Ok(result);
            }catch(Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpPost("Get-bus-For-Destination")]
        public async Task<IActionResult> GetBusForDestination(string from, string to)
        {
            try
            {
                var result =await _busService.GetBusForDestination(from, to);
                return Ok(result);
            }catch(Exception ex)
            {
                return NotFound(ex.ToString());
            }

        }

  
    }
}
