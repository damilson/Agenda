using ASP.NET_MVC.Cors;
using ASP.NET_MVC.ViewModels;
using Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NET_MVC.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaNegocio _pessoaNegocio;

        public PessoaController(IPessoaNegocio pessoaNegocio)
        {
            _pessoaNegocio = pessoaNegocio;
        }
        // GET: Pessoa
        //[AllowCrossSite]
        public JsonResult Index()
        {
            var listaPessoasDTO = _pessoaNegocio.Listar();
            var PVM = new PessoaViewModel();
            PVM.Pessoas = new List<PessoaViewModel>();
            PVM.Contatos = new List<ContatoViewModel>();
            PVM.Enderecos = new List<EnderecoViewModel>();

            PVM.Enderecos =
                listaPessoasDTO
                .SelectMany(p => p.Enderecos)
                .Select(endereco => new EnderecoViewModel
                {
                    EnderecoId = endereco.EnderecoId,
                    EnderecoNome = endereco.EnderecoNome,
                    Logradouro = new LogradouroViewModel
                    {
                        LogradouroId = endereco.Logradouro.LogradouroId,
                        Bairro = endereco.Logradouro.Bairro,
                        Cidade = endereco.Logradouro.Cidade,
                        Complemento = endereco.Logradouro.Complemento,
                        Estado = endereco.Logradouro.Estado,
                        Numero = endereco.Logradouro.Numero,
                        Tipo = endereco.Logradouro.Tipo
                    }
                }).ToList();

            PVM.Contatos = listaPessoasDTO
                .SelectMany(x => x.Contatos)
                .Select(contato => new ContatoViewModel
                {
                    ContatoId = contato.ContatoId,
                    Nome = contato.Nome,
                    Agrupador = contato.Agrupador,
                    TipoContato = contato.TipoContato
                }).ToList();

            PVM.Pessoas = listaPessoasDTO.Select(pessoa => new PessoaViewModel
            {
                PessoaId = pessoa.PessoaId,
                Nome = pessoa.Nome,
                Enderecos = PVM.Enderecos,
                Contatos = PVM.Contatos
            }).ToList();

            return new JsonResult{ Data = PVM, JsonRequestBehavior = JsonRequestBehavior.AllowGet } ;
        }

        // GET: Pessoa/Details/5
        public JsonResult Details(int id)
        {
            return Json(JsonRequestBehavior.AllowGet);
        }

        // POST: Pessoa/Create
        [HttpPost]
        public JsonResult Create(FormCollection collection)
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    //return RedirectToAction("Index");
            //}
            //catch
            //{
            //}
            return Json(JsonRequestBehavior.AllowGet);
        }

        // GET: Pessoa/Edit/5
        public JsonResult Edit(int id)
        {
            return Json(JsonRequestBehavior.AllowGet);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            //try
            //{
            //    // TODO: Add update logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}

            return Json(JsonRequestBehavior.AllowGet);
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
