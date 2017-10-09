using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using Negocio.Data;
using AutoMapper;
using Repositorio.Data;
using Repositorio.Model;
using System.Text.RegularExpressions;

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

        private void Validar(ContatoDTO pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.Nome))
                throw new Exception("O nome não pode ser nulo");

            var reg = new Regex(@"^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$");
            if (pessoa.TipoContato == Util.TipoContato.Email)
                if (reg.IsMatch(pessoa.Tipo))
                    throw new Exception("O email informado e inválido");

            reg = new Regex("^[1-9]{2}\\-[2-9][0-9]{7,8}$");
            if (pessoa.TipoContato == Util.TipoContato.Celular)
                if (reg.IsMatch(pessoa.Tipo))
                    throw new Exception("O celular informado e invalido");


        }
    }
}
