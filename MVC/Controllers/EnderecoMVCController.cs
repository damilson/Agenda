using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EnderecoMVCController : Controller
    {
        // GET: EnderecoMVC
        public ActionResult Index()
        {
            return View();
        }

        // GET: EnderecoMVC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnderecoMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnderecoMVC/Create
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

        // GET: EnderecoMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnderecoMVC/Edit/5
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

        // GET: EnderecoMVC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnderecoMVC/Delete/5
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
