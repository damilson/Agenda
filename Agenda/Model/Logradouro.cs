using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda.Model
{
    public class Logradouro
    {
        public virtual int LogradouroId { get; set; }

        public virtual int Numero { get; set; }

        public virtual string Bairro { get; set; }

        public virtual string Cidade { get; set; }

        public virtual string Estado { get; set; }
    }
}