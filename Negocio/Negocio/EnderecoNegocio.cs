using Negocio.Interfaces;
using Negocio.Data;
using Repositorio.Repositorio;
using AutoMapper;
using Repositorio.Model;
using Repositorio.Data;

namespace Negocio.Negocio
{
    public class EnderecoNegocio : IEnderecoNegocio
    {
        private readonly IEnderecoData _endereco;
        private readonly IMapper _mapper;

        public EnderecoNegocio(IMapper mapper)
        {
            _endereco = new EnderecoData();
            _mapper = mapper;
        }
        public EnderecoDTO Buscar(int Id)
        {
            var endereco = _endereco.Buscar(Id);

            var enderecoDTO = _mapper.Map<Endereco, EnderecoDTO>(endereco);

            return enderecoDTO;
        }
    }
}
