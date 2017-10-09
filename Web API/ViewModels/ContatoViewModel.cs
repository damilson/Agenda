using Util;

namespace Web_API.ViewModels
{
    public class ContatoViewModel
    {
        public int ContatoId { get; set; }

        public string Nome { get; set; }

        public TipoContato TipoContato { get; set; }

        public Agrupador Agrupador { get; set; }

        public string Tipo { get; set; }

        public int PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }
    }
}