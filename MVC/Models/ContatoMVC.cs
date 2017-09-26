﻿using Util;

namespace MVC.Models
{
    public class ContatoMVC
    {
        public virtual int ContatoMVCId { get; set; }

        public virtual int PessoaId { get; set; }
        public virtual PessoaMVC Pessoa { get; set; }

        public virtual TipoContato TipoContato { get; set; }
        public virtual string Celular { get; set; }
        public virtual string TelefoneResidencial { get; set; }
        public virtual string TelefoneComercial { get; set; }
        public virtual string Email { get; set; }
        public virtual string IM { get; set; }
        public virtual string Site { get; set; }

    }
}