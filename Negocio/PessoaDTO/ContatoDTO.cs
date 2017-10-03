using Util;

namespace Negocio.Data
{
    public class ContatoDTO
    {
        public int ContatoId { get; set; }

        public string Nome { get; set; }

        public TipoContato TipoContato { get; set; }

        public Agrupador Agrupador { get; set; }

        public int PessoaId { get; set; }
        public PessoaDTO Pessoa { get; set; }
    }
}
