using backend.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Services;
using AutoMapper;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using backend.Data;

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
        private readonly UserService _userService;

        public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, 
            IMapper mapper, IConfiguration config, UserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
            _userService = userService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
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
                var UsuarioDTO = _userService.info(login.Email);
                return Ok(new { token = tokenService.GeraToken(usuarioDTO), usuario = UsuarioDTO });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Invalido");
                return BadRequest(ModelState);
            }

        }

        [HttpPost("changepassword")]
        public async Task<ActionResult> ChangePassword([FromBody] LoginModel user)
        {
            var usuarioDto = _userService.info(user.Email);
            var usuario = await _userManager.FindByIdAsync(usuarioDto.Id);

            var result = await _userManager.ChangePasswordAsync(usuario, user.Password, user.NewPassword);

            if (result.Succeeded)
            {
                if(usuario != null)
                {
                    await _signInManager.SignInAsync(usuario, isPersistent: false);
                }
                return Ok("Senha alterada");
            }

            return BadRequest("Erro");
        }

    }
}
