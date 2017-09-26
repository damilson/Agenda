using System;
using Agenda.Model;

namespace Negocio.DTO
{
    public class LogradouroDTO
    {
        public int LogradouroDTOsId { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}