using System.Collections.Generic;

namespace UI.ViewModels
{
    public class PessoaViewModel
    {
        public virtual int PessoaId { get; set; }
        public virtual string Nome { get; set; }

        public List<EnderecoViewModel> Enderecos { get; set; }

        public List<ContatoViewModel> Contatos { get; set; }

        public List<PessoaViewModel> Pessoas { get; set; }

    }
}