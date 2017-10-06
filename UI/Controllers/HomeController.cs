using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var PVM = new PessoaViewModel();
            var listaPessoas = new List<PessoaViewModel>();
            foreach (var pessoa in model.Pessoas)
            {
                listaPessoas.Add(
                    new PessoaViewModel()
                    {
                        PessoaId = model.PessoaId,
                        Nome = model.Nome,
                        Pessoas = model.Pessoas,
                        Contatos = model.Contatos,
                        Enderecos = model.Enderecos
                    }
                );
            }
            PVM.Pessoas = listaPessoas;

            return PartialView("_Tabela", PVM);
        }
    }
}