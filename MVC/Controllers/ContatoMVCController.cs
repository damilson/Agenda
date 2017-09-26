using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ContatoMVCController : Controller
    {
        // GET: ContatoMVC
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContatoMVC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContatoMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContatoMVC/Create
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

        // GET: ContatoMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContatoMVC/Edit/5
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

        // GET: ContatoMVC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContatoMVC/Delete/5
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
