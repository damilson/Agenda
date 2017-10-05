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

        public PessoaNegocio()
        {
            _pessoa= new PessoaData();
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
            var listaPessoas = _pessoa.Listar();

            var clienteView = Mapper.Map<List<Pessoa>, List<PessoaDTO>>(listaPessoas);
            return clienteView;
        }

        public static object ChangeType(object value, Type conversionType)
        {
            return value;
        }
    }
}
