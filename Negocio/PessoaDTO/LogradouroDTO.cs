﻿using Util;

namespace Negocio.Data
{
    public class LogradouroDTO
    {
        public int LogradouroId { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public TipoLogradouro Tipo { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int EnderecoId { get; set; }
    }
}
