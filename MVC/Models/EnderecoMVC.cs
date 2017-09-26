namespace MVC.Models
{
    public class EnderecoMVC
    {
        public int EnderecoMVCId { get; set; }

        public string EnderecoNome { get; set; }

        public int PessoaId { get; set; }
        public PessoaMVC Pessoa { get; set; }

        public int LogradouroId { get; set; }
        public LogradouroMVC Logradouro { get; set; }
    }
}