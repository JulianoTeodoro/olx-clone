using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class UserService 
    {
        protected AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext _context, IMapper mapper)
        {
            this._context = _context;
            _mapper = mapper;
        }

        public IEnumerable<States> getStates()
        {
            return _context.states.ToList();
        }
         
        public UsuarioDTO info(string email)
        {
            var usuario = _context.usuario.Include(p => p.Ads).FirstOrDefault(p => p.Email == email);
            var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);
            return usuarioDto;
        }

        public UsuarioDTO infoId(string id)
        {
            var usuario = _context.usuario.Include(p => p.Ads).FirstOrDefault(p => p.Id == id);
            var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);
            return usuarioDto;
        }
    }
}
