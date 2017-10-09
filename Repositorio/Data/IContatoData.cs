using Repositorio.Model;
using System.Collections.Generic;

namespace Repositorio.Data
{
    public interface IContatoData
    {
        List<Contato> Listar();

        void Cadastrar(Contato contato);

        void Deletar(int Id);

        void Editar(Contato contato);

        Contato Buscar(int Id);
    }
}
