using System;
using System.Collections.Generic;
using Repositorio.Model;

namespace Negocio.Data
{
    public class PessoaDTO
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }

        public List<EnderecoDTO> Enderecos { get; set; }

        public List<ContatoDTO> Contatos { get; set; }

    }
}
