using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {

        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public AdsController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<AdsDTO>> CriarAds(AdsDTO adsDto)
        {
            try
            {
                Ads ads = _mapper.Map<Ads>(adsDto);
                _uof.AdsRepository.Add(ads);
                await _uof.Commit();
                var adsDTO = _mapper.Map<AdsDTO>(ads);
                return new CreatedAtRouteResult("ObterAds", new { ads = adsDTO.AdsId }, adsDTO);
            }
            catch (DbUpdateException)
            {
                _uof.Dispose();
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "Erro de criação" });
            }
        }

        [HttpPost("adicionarImagem")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<ICollection<Images>>> AdicionarImagem(ICollection<Images> images)
        {
            try
            {
                if (images != null)
                {
                    foreach (Images image in images)
                    {
                        _uof.ImageRepository.Add(image);
                    }
                    await _uof.Commit();
                    return Ok("Imagens adicionadas!!");
                }
                return BadRequest("Erro");
            }
            catch(DbUpdateException)
            {
                _uof.Dispose();
                return BadRequest("Erro");
            }
        }

        [HttpGet(Name = "ObterAds")]
        public async Task<ActionResult<List<AdsDTO>>> GetAds()
        {
            try
            {
                var ads = await _uof.AdsRepository.GetAsync().ToListAsync();
                var adsDto = _mapper.Map<List<AdsDTO>>(ads);

                return adsDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { message = "Erro ao consultar" });
            }
        }

        [HttpGet("{id:int:min(1):maxlength(5)}")]
        public async Task<ActionResult<AdsDTO>> GetAdsById(int id)
        {
            try
            {
                var ads = await _uof.AdsRepository.GetAdsById(id);

                if (ads is null)
                {
                    return NotFound("Anuncio não encontrado");
                }
                return _mapper.Map<AdsDTO>(ads);
            }
            catch(Exception)
            {
                return BadRequest("");
            }
            
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<IEnumerable<AdsDTO>>> GetAdsByTitle(string title)
        {
            var ads = await _uof.AdsRepository.GetByTitle(title);

            return _mapper.Map<List<AdsDTO>>(ads);
        }


        [HttpPut("{id:int:min(1):maxlength(5)}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<AdsDTO>> Put(int id, AdsDTO adsDto)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new { message = "Erro de edição" });
            }
            try
            {
                var ads = _mapper.Map<Ads>(adsDto);

                _uof.AdsRepository.UpdateAsync(ads);
                await _uof.Commit();

                return Ok(adsDto);
            }
            catch(DbUpdateException)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new { message = "Anuncio não encontrado" });
            }
        }


        [HttpDelete("{id:int:min(1):maxlength(5)}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public ActionResult<AdsDTO> Delete(int id)
        {
            try
            {
                var ads = _uof.AdsRepository.GetAsync().Include(p => p.images).SingleOrDefault(p => p.AdsId == id);

                if (!(ads.images is null))
                {
                    foreach(Images image in ads.images)
                    {
                        _uof.ImageRepository.DeleteAsync(image);
                    }
                }

                _uof.AdsRepository.DeleteAsync(ads);
                _uof.Commit();
                return StatusCode(StatusCodes.Status200OK, new { message = "Anuncio removido" });

            }
            catch(Exception)
            {
                return BadRequest("Erro ao deletar");
            }
        }


    }
}
