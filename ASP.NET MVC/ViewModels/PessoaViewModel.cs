using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC.ViewModels
{
    public class PessoaViewModel
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }

        public List<EnderecoViewModel> Enderecos { get; set; }

        public List<ContatoViewModel> Contatos { get; set; }
    }
}