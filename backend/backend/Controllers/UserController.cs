using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using backend.Models;
using backend.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using backend.Data;
using AutoMapper;

namespace backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper? _mapper;
        private readonly UserService _userService;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("states")]
        public ActionResult<IEnumerable<States>> GetStates()
        {
            var states = _userService.getStates();
            return Ok(new { states = states });
        }

        [HttpPost("me")]
        public UsuarioDTO GetInfo([FromBody] IDDTO id)
        {
            var user = _userService.infoId(id.ID);

            return user;
        }

    }
}
