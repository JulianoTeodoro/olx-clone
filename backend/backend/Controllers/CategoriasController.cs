using AutoMapper;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : Controller
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public CategoriasController(IUnitOfWork uof, IMapper mapper, IWebHostEnvironment sistema)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet(Name = "ObterCategoria")]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            return await _uof.CategoriaRepository.GetAsync().ToListAsync();
        }

        [HttpPost("criarCategoria")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Failed");
            }
            try
            {
               _uof.CategoriaRepository.Add(categoria);
               await _uof.Commit();
               return new CreatedAtRouteResult("ObterCategoria", new { categoria = categoria.CategoriaId }, categoria);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Erro ao criar" });
            }

        }
    }
}
