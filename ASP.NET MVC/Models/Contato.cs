using Util;

namespace ASP.NET_MVC.Model
{
    public class Contato
    {
        public int ContatoId { get; set; }

        public string Nome { get; set; }

        public TipoContato TipoContato { get; set; }

        public Agrupador Agrupador { get; set; }

        public string Tipo { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}