using Agenda.Model;
using Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Negocio
{
    public interface IPessoaServico
    {
        List<PessoaDTO> Listar();
    }
}
