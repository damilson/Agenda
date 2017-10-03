namespace Negocio.Data
{
    public class EnderecoDTO
    {
        public int EnderecoId { get; set; }
        public string EnderecoNome { get; set; }
        public int PessoaId { get; set; }
        public PessoaDTO Pessoa { get; set; }
        public int? LogradouroId { get; set; }
        public LogradouroDTO Logradouro { get; set; }
    }
}
