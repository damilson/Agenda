using Repositorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Data
{
    public interface IPessoaData
    {
        List<Pessoa> Listar();

        void Cadastrar(Pessoa pessoa);

        void Deletar(int Id);

        void Editar(Pessoa pessoa);
    }
}
