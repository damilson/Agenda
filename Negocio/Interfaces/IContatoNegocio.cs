using Negocio.Data;
using Repositorio.Model;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IContatoNegocio
    {
        List<ContatoDTO> Listar();

        void Cadastrar(ContatoDTO contato);

        void Deletar(int Id);

        void Editar(ContatoDTO contato);
    }
}
