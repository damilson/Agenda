using System.Collections.Generic;

namespace ASP.NET_MVC.Model
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }

        public List<Endereco> Enderecos { get; set; }

        public List<Contato> Contatos { get; set; }
    }
}