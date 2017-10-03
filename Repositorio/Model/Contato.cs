using Util;

namespace Repositorio.Model
{
    public class Contato
    {
        public virtual int ContatoId { get; set; }

        public virtual string Nome { get; set; }

        public virtual TipoContato TipoContato { get; set; }

        public virtual Agrupador Agrupador { get; set; }

        public virtual int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}