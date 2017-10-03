using System.Collections.Generic;
using Repositorio.Model;
using Repositorio.Repositorio;
using System.Linq;

namespace Repositorio.Data
{
    public class ContatoData : IContatoData
    {
        private readonly IRepositorio _repositorio;

        public ContatoData()
        {
            _repositorio = new Repositorio.Repositorio();
        }

        public void Cadastrar(Contato contato)
        {
            _repositorio.InsertAndSaveChanges(contato);
        }

        public void Deletar(int Id)
        {
            _repositorio.DeleteAndSaveChanges<Contato>(x => x.ContatoId == Id);
        }

        public void Editar(Contato contato)
        {
            _repositorio.UpdateAndSaveChanges(contato);
        }

        public List<Contato> Listar()
        {
            var contatos = _repositorio.List<Contato>().ToList();

            return contatos;
        }
    }
}
