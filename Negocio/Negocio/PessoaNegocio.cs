using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using Negocio.Data;
using Repositorio.Repositorio;
using Repositorio.Model;
using System.Linq;

namespace Negocio.Negocio
{
    public class PessoaNegocio : IPessoaNegocio
    {
        private readonly IRepositorio _repositorio;

        public PessoaNegocio()
        {
            _repositorio = new Repositorio.Repositorio.Repositorio();
        }

        public void Cadastrar(PessoaDTO pessoa)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int Id)
        {
            throw new NotImplementedException();
        }

        public void Editar(PessoaDTO pessoa)
        {
            throw new NotImplementedException();
        }

        public List<PessoaDTO> Listar()
        {
            var listaPessoas = _repositorio.List<Pessoa>().ToList();

            var listaPessoaDTO = new List<PessoaDTO>();

            foreach (var pessoa in listaPessoas)
            {
                listaPessoas.Add(new PessoaDTO
                {
                    PessoaId = pessoa.PessoaId,
                    Contatos = (ContatoDTO)pessoa.Contatos.ToList(),
                    Enderecos = pessoa.Enderecos,
                    Nome = pessoa.Nome
                });
            }
            return listaPessoas.ToList();

        }

        public static object ChangeType(object value, Type conversionType)
        {
            return value;
        }
    }
}
