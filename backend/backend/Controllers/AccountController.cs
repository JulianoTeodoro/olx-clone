using backend.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Services;
using AutoMapper;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IMapper? _mapper;
        private readonly IConfiguration _config;

        public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, 
            IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return $"AutorizaController acessado em: {DateTime.Now.ToLongDateString()}";
        }

        [HttpPost("register")]
        public async Task<ActionResult<UsuarioDTO>> Register([FromBody] RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Erro de registro!");
            }

            var user = new Usuario
            {
                Nome = register.Nome,
                SobreNome = register.Sobrenome,
                UserName = register.Email,
                Email = register.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            var usuarioDTO = _mapper.Map<UsuarioDTO>(user);

            var tokenService = new TokenService(_config);
            return Ok(tokenService.GeraToken(usuarioDTO));
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDTO>> Login([FromBody] LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Erro de login!");
            }

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password,
                isPersistent: false, lockoutOnFailure: false);

            var usuarioDTO = new UsuarioDTO
            {
                Email = login.Email,
                Password = login.Password,
            };

            var tokenService = new TokenService(_config);

            if (result.Succeeded)
            {
                return Ok(tokenService.GeraToken(usuarioDTO));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Invalido");
                return BadRequest(ModelState);
            }

        }

    }
}
