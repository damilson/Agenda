using Negocio.Interfaces;
using System.Collections.Generic;
using Negocio.Data;
using Repositorio.Model;
using AutoMapper;
using Repositorio.Data;
using System;
using System.Linq;

namespace Negocio.Negocio
{
    public class PessoaNegocio : IPessoaNegocio
    {
        private readonly IPessoaData _pessoa;
        private readonly IEnderecoData _endereco;
        private readonly ILogradouroData _logradouro;

        private readonly IMapper _mapper;

        public PessoaNegocio(IMapper mapper)
        {
            _pessoa = new PessoaData();
            _endereco = new EnderecoData();
            _logradouro = new LogradoruoData();
            _mapper = mapper;
        }

        public void Cadastrar(PessoaDTO pessoa)
        {
            Validar(pessoa);
            var pessoaData = _mapper.Map<PessoaDTO, Pessoa>(pessoa);

            _pessoa.Cadastrar(pessoaData);
        }

        public void Deletar(int Id)
        {
            _pessoa.Deletar(Id);
        }

        public void Editar(PessoaDTO pessoaDTO)
        {
            Validar(pessoaDTO);
            var pessoa = _mapper.Map<PessoaDTO, Pessoa>(pessoaDTO);

            var listanderecoData = new List<Endereco>();
            foreach (var endereco in pessoaDTO.Enderecos)
            {
                var enderecoData = _mapper.Map<EnderecoDTO, Endereco>(endereco);
                var logradouroData = _mapper.Map<LogradouroDTO, Logradouro>(endereco.Logradouro);

                _endereco.Editar(enderecoData);
                _logradouro.Editar(logradouroData);
            }

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

        private void Validar(PessoaDTO pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.Nome))
                throw new Exception("O nome não pode ser nulo");

            if (pessoa.Enderecos != null)
            {
                var listaEndereco = _endereco.ListaEndereco();
                foreach (var endereco in pessoa.Enderecos)
                {
                    if (string.IsNullOrEmpty(endereco.Logradouro.Bairro))
                        throw new Exception("O bairro não pode ser nulo");

                    if (string.IsNullOrEmpty(endereco.Logradouro.Cidade))
                        throw new Exception("A cidade não pode ser nula");

                    if (string.IsNullOrEmpty(endereco.Logradouro.Complemento))
                        throw new Exception("O compemento não pode ser nulo");

                    if (string.IsNullOrEmpty(endereco.Logradouro.Estado))
                        throw new Exception("O estado não pode ser nulo");

                    if (endereco.Logradouro.Numero == 0)
                        throw new Exception("O numero não pode ser nulo");
                }
            }
        }
    }
}
