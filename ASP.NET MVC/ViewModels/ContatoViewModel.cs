using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util;

namespace ASP.NET_MVC.ViewModels
{
    public class ContatoViewModel
    {
        public int ContatoId { get; set; }

        public string Nome { get; set; }

        public TipoContato TipoContato { get; set; }

        public Agrupador Agrupador { get; set; }

        public int PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }
    }
}