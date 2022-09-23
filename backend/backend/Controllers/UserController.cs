using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using backend.Models;
using backend.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthenticatedUser _user;


        private UserService _userService { get; set; }
        public UserController(UserService userService, AuthenticatedUser user)
        {
            _userService = userService;
            _user = user;
        }

        [HttpGet("states")]
        public ActionResult<IEnumerable<States>> GetStates()
        {
            var states = _userService.getStates();
            return Ok(new { states = states });
        }

        [HttpPost("me")]
        public IEnumerable<Claim> GetInfo([FromBody] TokenDTO token)
        {
            var user = _user.GetClaimsIdentity();

            return user;
        }
    }
}
