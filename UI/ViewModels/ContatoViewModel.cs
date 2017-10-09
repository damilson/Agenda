using System.ComponentModel.DataAnnotations;
using UI.Enumeradores;

namespace UI.ViewModels
{
    public class ContatoViewModel
    {
        public int ContatoId { get; set; }

        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [Display(Name ="Tipo de contato")]
        public TipoContato TipoContato { get; set; }

        [Display(Name ="Grupo")]
        public Agrupador Agrupador { get; set; }

        [Display(Name ="Contato")]
        public string Tipo { get; set; }

        public int PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }
    }


}