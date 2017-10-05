using AutoMapper;
using Negocio.Data;
using Repositorio.Model;

namespace Negocio.Mappers
{
    public class PessoaMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "PessoaMappingProfile"; }
        }

        protected void Configure()
        {
            CreateMap<Pessoa, PessoaDTO>();
        }
    }
}
