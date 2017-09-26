using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.DTO
{
    public class PessoaDTO
    {
        public int PessoaDTOId { get; set; }

        public string Nome { get; set; }

        public List<EnderecoDTO> EnderecoLista { get; set; }

        public List<ContatoDTO> ListaContatos { get; set; }
    }
}