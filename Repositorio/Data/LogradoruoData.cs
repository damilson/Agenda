using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositorio.Model;
using Repositorio.Repositorio;

namespace Repositorio.Data
{
    public class LogradoruoData : ILogradouroData
    {
        private readonly IRepositorio _repositorio;

        public LogradoruoData()
        {
            _repositorio = new Repositorio.Repositorio();
        }
        public Logradouro Buscar(int id)
        {
            return _repositorio.Find<Logradouro>(x => x.LogradouroId == id);
        }

        public void Editar(Logradouro logradouro)
        {
            _repositorio.UpdateAndSaveChanges(logradouro);
        }
    }
}