using AutoMapper;
using Negocio.Data;
using Repositorio.Model;

namespace Negocio.Mappers
{
    public class AgendaMappingProfile : Profile
    {
        public AgendaMappingProfile()
        {
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
        }
    }
}
