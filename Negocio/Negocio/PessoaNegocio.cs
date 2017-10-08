using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using Negocio.Data;
using Repositorio.Repositorio;
using Repositorio.Model;
using System.Linq;
using AutoMapper;
using Repositorio.Data;

namespace Negocio.Negocio
{
    public class PessoaNegocio : IPessoaNegocio
    {
        private readonly IPessoaData _pessoa;
        private readonly IMapper _mapper;

        public PessoaNegocio(IMapper mapper)
        {
            _pessoa= new PessoaData();
            _mapper = mapper;
        }

        public void Cadastrar(PessoaDTO pessoa)
        {
            var pessoaData = _mapper.Map<PessoaDTO, Pessoa>(pessoa);

            _pessoa.Cadastrar(pessoaData);
        }

        public void Deletar(int Id)
        {
            _pessoa.Deletar(Id);
        }

        public void Editar(PessoaDTO pessoaDTO)
        {
            var pessoa = _mapper.Map<PessoaDTO, Pessoa>(pessoaDTO);

            _pessoa.Editar(pessoa);
        }

        public List<PessoaDTO> Listar()
        {
            var listaPessoas = _pessoa.Listar();

            var clienteView = _mapper.Map<List<Pessoa>, List<PessoaDTO>>(listaPessoas);
            return clienteView;
        }

        public PessoaDTO Buscar(int Id)
        {
            var pessoa = _pessoa.Buscar(Id);

            var pessoaDTO = _mapper.Map<Pessoa, PessoaDTO>(pessoa);

            return pessoaDTO;
        }
    }
}
