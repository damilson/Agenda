namespace Web_API.ViewModels
{
    public class EnderecoViewModel
    {
        public int EnderecoId { get; set; }
        public string EnderecoNome { get; set; }
        public int PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }
        public int? LogradouroId { get; set; }
        public LogradouroViewModel Logradouro { get; set; }
    }
}