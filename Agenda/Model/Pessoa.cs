using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda.Model
{
    public class Pessoa
    {
        public virtual int PessoaId { get; set; }

        public virtual string Nome { get; set; }

        public virtual List<Endereco> EnderecoLista { get; set; }

        public virtual List<Contato> ListaContatos { get; set; }
    }
}