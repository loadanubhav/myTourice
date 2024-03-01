using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TouriceDatabases.Modals;
using TouriceServices.IServices;

namespace Tourice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityApiController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityApiController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("All-City")]
        public async Task< IActionResult> GetCitiesInIndia()
        {
            
            try
            {
                var cities = await _cityService.getCityList();
                return Ok(cities);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
