using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Model
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string EnderecoNome { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int LogradouroId { get; set; }
        public Logradouro Logradouro { get; set; }
    }
}