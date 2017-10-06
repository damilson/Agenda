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
        public JsonResult Index()
        {
            var listaPessoasDTO = _pessoaNegocio.Listar();
            var listaPessoasViewModels = new List<PessoaViewModel>();
            var listaContatos = new List<ContatoViewModel>();
            var listaEnderecos = new List<EnderecoViewModel>();

            listaEnderecos =
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

            listaContatos = listaPessoasDTO
                .SelectMany(x => x.Contatos)
                .Select(contato => new ContatoViewModel
                {
                    ContatoId = contato.ContatoId,
                    Nome = contato.Nome,
                    Agrupador = contato.Agrupador,
                    TipoContato = contato.TipoContato
                }).ToList();

            listaPessoasViewModels = listaPessoasDTO.Select(pessoa => new PessoaViewModel
            {
                PessoaId = pessoa.PessoaId,
                Nome = pessoa.Nome,
                Enderecos = listaEnderecos,
                Contatos = listaContatos
            }).ToList();

            return Json(listaPessoasViewModels, JsonRequestBehavior.AllowGet);
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
