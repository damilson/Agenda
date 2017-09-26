using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PessoaMVC
    {
        public int PessoaId { get; set; }

        public string Nome { get; set; }

        public List<EnderecoMVC> EnderecoLista { get; set; }

        public List<ContatoMVC> ListaContatos { get; set; }
    }
}