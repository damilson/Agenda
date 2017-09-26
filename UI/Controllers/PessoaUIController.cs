using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class PessoaUIController : Controller
    {
        // GET: PessoaUI
        public ActionResult Index()
        {
            return View();
        }

        // GET: PessoaUI/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PessoaUI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaUI/Create
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

        // GET: PessoaUI/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PessoaUI/Edit/5
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

        // GET: PessoaUI/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PessoaUI/Delete/5
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
