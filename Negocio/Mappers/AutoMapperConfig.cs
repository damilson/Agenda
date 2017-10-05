using AutoMapper;
using Negocio.Data;
using Repositorio.Model;

namespace Negocio.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<PessoaMappingProfile>();

                x.AddProfile<PessoaDTOMappingProfile>();
            });
        }
    }
}
