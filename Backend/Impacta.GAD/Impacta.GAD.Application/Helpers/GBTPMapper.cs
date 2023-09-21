using AutoMapper;
using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Domain.Identity;
using Impacta.GAD.Domain.Models;

namespace Impacta.GAD.Application.Helpers
{
    public class GBTPMapper : Profile
    {
        public GBTPMapper()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<DNS, DNSDTO>().ReverseMap();
            CreateMap<BancoDados, BancoDadosDTO>().ReverseMap();
            CreateMap<Chamado, ChamadoDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioAddDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioUpdateDTO>().ReverseMap();
        }
    }
}
