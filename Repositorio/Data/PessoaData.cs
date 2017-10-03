using System.Collections.Generic;
using Repositorio.Model;
using Repositorio.Repositorio;
using System.Linq;
using Repositorio.Data;

namespace Repositorio.Data
{
    public class PessoaData : IPessoaData
    {

        private readonly IRepositorio _repositorio;

        public PessoaData()
        {
            _repositorio = new Repositorio.Repositorio();
        }

        public void Cadastrar(Pessoa pessoa)
        {
            _repositorio.InsertAndSaveChanges(pessoa);
        }

        public void Deletar(int Id)
        {
            _repositorio.DeleteAndSaveChanges<Pessoa>(x => x.PessoaId == Id);
        }

        public void Editar(Pessoa pessoa)
        {
            _repositorio.UpdateAndSaveChanges(pessoa);
        }

        public List<Pessoa> Listar()
        {
            var pessoas = _repositorio.List<Pessoa>().ToList();

            return pessoas;
        }                                                        
    }
}
