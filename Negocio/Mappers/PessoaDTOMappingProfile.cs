using AutoMapper;
using Negocio.Data;
using Repositorio.Model;

namespace Negocio.Mappers
{
    public class PessoaDTOMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "PessoaDTOMappingProfile"; }
        }

        protected void configure()
        {
            CreateMap<PessoaDTO, Pessoa>();
        }
    }
}
