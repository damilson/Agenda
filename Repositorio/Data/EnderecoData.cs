using Repositorio.Model;
using Repositorio.Repositorio;

namespace Repositorio.Data
{
    public class EnderecoData : IEnderecoData
    {
        private readonly IRepositorio _repositorio;

        public EnderecoData()
        {
            _repositorio = new Repositorio.Repositorio();
        }
        public Endereco Buscar(int Id)
        {
            return _repositorio.Find<Endereco>(x => x.EnderecoId == Id);
        }

        public void Editar(Endereco endereco)
        {
            _repositorio.UpdateAndSaveChanges(endereco);
        }
    }
}