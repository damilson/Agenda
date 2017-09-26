namespace Negocio.DTO
{
    public class EnderecoDTO
    {
        public int EnderecoDTOId { get; set; }

        public string EnderecoNome { get; set; }

        public int PessoaId { get; set; }
        public PessoaDTO Pessoa { get; set; }

        public int LogradouroId { get; set; }
        public LogradouroDTO Logradouro { get; set; }
    }
}