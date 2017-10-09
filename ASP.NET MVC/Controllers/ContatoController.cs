using ASP.NET_MVC.ViewModels;
using Negocio.Data;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util;

namespace ASP.NET_MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoNegocio _contato;

        public ContatoController(IContatoNegocio contato)
        {
            _contato = contato;
        }

        public JsonResult Details(int id)
        {
            var CVM = new ContatoViewModel();
            var contato = _contato.Buscar(id);

            CVM.ContatoId = contato.ContatoId;
            CVM.Nome = contato.Nome;
            CVM.TipoContato = contato.TipoContato;
            CVM.Agrupador = contato.Agrupador;
            CVM.Tipo = contato.Tipo;
            CVM.PessoaId = contato.PessoaId;

            return new JsonResult { Data = CVM, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult Create(FormCollection collection)
        {

            var pessoaId = collection["PessoaId"].ToString();
            var nome = collection["Nome"].ToString();
            var tipoContato = collection["TipoContato"].ToString();
            var tipo = collection["Tipo"].ToString();
            var agrupador = collection["Agrupador"].ToString();

            var contato = new ContatoDTO
            {
                PessoaId = int.Parse(pessoaId),
                Nome = nome,
                TipoContato = (TipoContato)int.Parse(tipoContato),
                Agrupador = (Agrupador)int.Parse(agrupador),
                Tipo = tipo
            };

            try
            {
                _contato.Cadastrar(contato);
            }
            catch (Exception ex)
            {
                return Alerta.CriaMensagemErro(ex);
            }
            return Alerta.CriaMensagemSucesso("Sucesso ao cadastrar contato.");
        }

        public JsonResult Edit(FormCollection collection)
        {
            var contatoId = collection["ContatoId"].ToString();
            var pessoaId = collection["PessoaId"].ToString();
            var nome = collection["Nome"].ToString();
            var tipoContato = collection["TipoContato"].ToString();
            var tipo = collection["Tipo"].ToString();
            var agrupador = collection["Agrupador"].ToString();

            var contato = new ContatoDTO
            {
                ContatoId = int.Parse(contatoId),
                PessoaId = int.Parse(pessoaId),
                Nome = nome,
                TipoContato = (TipoContato)int.Parse(tipoContato),
                Agrupador = (Agrupador)int.Parse(agrupador),
                Tipo = tipo
            };

            try
            {
                _contato.Editar(contato);
            }
            catch (Exception ex)
            {
                return Alerta.CriaMensagemErro(ex);
            }
            return Alerta.CriaMensagemSucesso("Sucesso ao editar contato.");
        }

        public JsonResult Delete(int id)
        {
            try
            {
                _contato.Deletar(id);
            }
            catch (Exception ex)
            {
                return Alerta.CriaMensagemErro(ex);
            }
            return Alerta.CriaMensagemSucesso("Contato excluido com sucesso.");
        }
        
    }
}
