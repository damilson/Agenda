using System.Collections.Generic;

namespace Web_API.Model
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }

        public List<Endereco> Enderecos { get; set; }

        public List<Contato> Contatos { get; set; }
    }
}