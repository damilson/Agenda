using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Model;
using UI.ViewModels;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RetornaTabela(PessoaViewModel model)
        {
            return PartialView("_Tabela", model);
        }

        public ActionResult Details(PessoaViewModel model)
        {
            var PVM = new PessoaViewModel()
            {
                Id = model.Pessoa.PessoaId,
                Nome = model.Pessoa.Nome,
                Enderecos = model.Pessoa.Enderecos,
                Contatos = model.Pessoa.Contatos
            };

            return PartialView("_Editar", PVM);
        }
    }
}