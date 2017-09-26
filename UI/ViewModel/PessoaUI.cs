using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.ViewModel
{
    public class PessoaUI
    {
        public int PessoaUIId { get; set; }

        public string Nome { get; set; }

        public List<EnderecoUI> EnderecoLista { get; set; }

        public List<ContatoUI> ListaContatos { get; set; }
    }
}