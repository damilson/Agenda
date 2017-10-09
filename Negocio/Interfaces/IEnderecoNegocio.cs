using Negocio.Data;
using Repositorio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IEnderecoNegocio
    {
        EnderecoDTO Buscar(int id);
    }
}
