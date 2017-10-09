using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using Negocio.Data;
using AutoMapper;
using Repositorio.Data;
using Repositorio.Model;

namespace Negocio.Negocio
{
    public class ContatoNegocio : IContatoNegocio
    {
        private readonly IMapper _mapper;
        private readonly IContatoData _contato;

        public ContatoNegocio(IMapper mapper)
        {
            _mapper = mapper;
            _contato = new ContatoData();
        }

        public void Cadastrar(ContatoDTO contato)
        {
            var contatoData = _mapper.Map<ContatoDTO, Contato>(contato);

            _contato.Cadastrar(contatoData);
        }

        public void Deletar(int Id)
        {
            _contato.Deletar(Id);
        }

        public void Editar(ContatoDTO contato)
        {
            var contatoData = _mapper.Map<ContatoDTO, Contato>(contato);

            _contato.Editar(contatoData);
        }

        public List<ContatoDTO> Listar()
        {
            throw new NotImplementedException();
        }

        public ContatoDTO Buscar(int Id)
        {
            var contato = _contato.Buscar(Id);
            var contatoDTO = _mapper.Map<Contato, ContatoDTO>(contato);

            return contatoDTO;
        }
    }
}
