﻿using System.Collections.Generic;

namespace ASP.NET_MVC.ViewModels
{
    public class PessoaViewModel
    {
        public int PessoaId { get; set; }

        public string Nome { get; set; }

        public List<EnderecoViewModel> Enderecos { get; set; }

        public List<ContatoViewModel> Contatos { get; set; }

        public List<PessoaViewModel> Pessoas { get; set; }
    }
}