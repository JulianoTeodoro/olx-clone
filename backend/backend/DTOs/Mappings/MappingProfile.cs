using AutoMapper;
using backend.Models;
using backend.Services;

namespace backend.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioToken, TokenDTO>().ReverseMap();
        }
    }
}
