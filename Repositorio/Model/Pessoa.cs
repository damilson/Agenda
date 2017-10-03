using System.Collections.Generic;

namespace Repositorio.Model
{
    public class Pessoa
    {
        public virtual int PessoaId { get; set; }
        public virtual string Nome { get; set; }

        public virtual List<Endereco> Enderecos { get; set; }

        public virtual List<Contato> Contatos { get; set; }
    }
}