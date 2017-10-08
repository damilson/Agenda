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
            //var PVM = new PessoaViewModel();
            //var listaPessoas = new List<Pessoa>();
            //foreach (var pessoa in model.Pessoas)
            //{
            //    listaPessoas.Add(
            //        new Pessoa()
            //        {
            //            PessoaId = model.PessoaId,
            //            Nome = model.Nome,
            //            Contatos = model.Contatos,
            //            Enderecos = model.Enderecos
            //        }
            //    );
            //}
            //PVM.Pessoas = listaPessoas;

            return PartialView("_Tabela", model);
        }
    }
}