using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.Enumeradores;

namespace UI.ViewModels
{
    public class LogradouroViewModel
    {
        public int LogradouroId { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public TipoLogradouro Tipo { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}