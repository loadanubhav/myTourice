using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TouriceDatabases.Modals;
using TouriceServices.IServices;

namespace Tourice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _userServices;
        private IMapper _mapper;
        public UserController(IUserServices services, IMapper mapper)
        {
            _userServices = services;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] tblUserLogin user)
        {
            try
            {
                var result = _userServices.Login(_mapper.Map<tblUser>(user));
                return Ok(result);
            }catch(Exception ex)
            {
                return NotFound(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("user-Signup")]
        public async Task<IActionResult> signUp(tblUser user)
        {
            try
            {
                var result =await _userServices.SignUpUser(user);
                return Ok(result);
            }catch(Exception ex)
            {
                return NotFound(ex);
            }
        }
        [Authorize(Roles ="Admin")]
        [HttpPost("AuthorizationWoriking")]
        public IActionResult getUserType()
        {
            return Ok("Cool Working");
        }  
        [Authorize(Roles ="User")]
        [HttpPost("User-LogedIn")]
        public IActionResult UserLogin()
        {
            return Ok("user Loged In");
        }
    }
}
