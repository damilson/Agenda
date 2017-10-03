using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util;

namespace Repositorio.Model
{
    public class Logradouro
    {
        public virtual int LogradouroId { get; set; }
        public virtual int Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual TipoLogradouro Tipo { get; set; }
        public virtual int Comercial { get; set; }
        public virtual int Bairro { get; set; }
        public virtual int Cidade { get; set; }
        public virtual int Estado { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}