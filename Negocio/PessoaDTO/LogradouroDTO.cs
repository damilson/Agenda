using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Negocio.Data
{
    public class LogradouroDTO
    {
        public int LogradouroId { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public TipoLogradouro Tipo { get; set; }
        public int Comercial { get; set; }
        public int Bairro { get; set; }
        public int Cidade { get; set; }
        public int Estado { get; set; }
        public int EnderecoId { get; set; }
        public EnderecoDTO Endereco { get; set; }
    }
}
