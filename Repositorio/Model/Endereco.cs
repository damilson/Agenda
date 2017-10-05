using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositorio.Model
{
    public class Endereco
    {
        public virtual int EnderecoId { get; set; }
        public virtual string EnderecoNome { get; set; }
        public virtual int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual List<Endereco> EnderecoLista { get; set; }
    }
}