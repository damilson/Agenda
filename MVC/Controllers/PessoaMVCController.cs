using Negocio.DTO;
using Negocio.Negocio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PessoaMVCController : Controller
    {
        private readonly IPessoaServico _pessoa;

        public PessoaMVCController(IPessoaServico pessoa)
        {
            _pessoa = pessoa;
        }

        // GET: PessoaMVC
        public JsonResult Index()
        {
            var pessoa = _pessoa.Listar();
            return Json(pessoa, JsonRequestBehavior.AllowGet);
        }

        // GET: PessoaMVC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PessoaMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaMVC/Create
        [HttpPost]
        public JsonResult Create(FormCollection formData)
        {

            var enderecos = formData["txt-endereco"].ToString().Split(',');
            var numeros = formData["txt-numero"].ToString().Split(',');
            var complementos = formData["txt-complemento"].ToString().Split(',');
            var tipos = formData["txt-tipo"].ToString().Split(',');
            var celular = formData["txt-celular"].ToString().Split(',');

            var enderecoLista = new List<EnderecoDTO>();
            for (int i = 0; i <= enderecos.Length; i++)
            {
                enderecoLista.Add(new EnderecoDTO()
                {
                    EnderecoNome = enderecos[i].ToString(),
                });
            }
            
            var pessoa = new PessoaDTO()
            {
                Nome = formData["txt-nome"].ToString(),
                EnderecoLista = enderecoLista,
            };
            return Json("");
        }

        // GET: PessoaMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PessoaMVC/Edit/5
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

        // GET: PessoaMVC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PessoaMVC/Delete/5
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
