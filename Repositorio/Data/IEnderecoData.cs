using Repositorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Data
{
    public interface IEnderecoData
    {
        Endereco Buscar(int Id);

        void Editar(Endereco endereco);
    }
}
