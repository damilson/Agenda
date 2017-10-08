using Negocio.Data;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IPessoaNegocio
    {
        List<PessoaDTO> Listar();

        void Cadastrar(PessoaDTO pessoa);

        void Deletar(int Id);

        void Editar(PessoaDTO pessoa);

        PessoaDTO Buscar(int Id);
    }
}
