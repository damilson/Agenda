using Negocio.Interfaces;
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
            _pessoaNegocio.Listar();
            return Json("Teste de aplicação", JsonRequestBehavior.AllowGet);
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
