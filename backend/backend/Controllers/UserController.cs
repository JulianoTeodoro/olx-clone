using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using backend.Models;

namespace backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService { get; set; }
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("states")]
        public ActionResult<IEnumerable<States>> GetStates()
        {
            var states = _userService.getStates();
            return Ok(new { states = states });
        }
    }
}
