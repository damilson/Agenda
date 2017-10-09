using System.Collections.Generic;
using Web_API.Model;

namespace Web_API.ViewModels
{
    public class PessoaViewModel
    {
        public List<Pessoa> Pessoas { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}