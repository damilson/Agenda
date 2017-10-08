using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UI.Enumeradores;
using UI.Model;

namespace UI.ViewModels
{
    public class PessoaViewModel
    {

        public int Id { get; set; }

        [Display(Name =@"Nome")]
        public string Nome { get; set; }

        [Display(Name =@"Endereço")]
        public string Endereco { get; set; }

        [Display(Name =@"Numero")]
        public int Numero { get; set; }

        [Display(Name=@"Complemento")]
        public string Complemento { get; set; }

        [Display(Name =@"Tipo de comlemento")]
        public TipoLogradouro Tipo { get; set; }

        [Display(Name =@"Bairro")]
        public string Bairro { get; set; }

        [Display(Name ="Cidade")]
        public string Cidade { get; set; }

        [Display(Name =@"Estado")]
        public string Estado { get; set; }

        public List<Pessoa> Pessoas { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Contato> Contatos { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}