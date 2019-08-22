using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeptIT.Models;
using System.Data.Entity;

namespace DeptIT.Controllers
{
    public class JqueryController : Controller
    {
        // GET: Jquery
        DBContext db = new DBContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Products);
        }

        // Просмотр подробных сведений о книге
        public ActionResult Details(int id)
        {
            Product comp = db.Products.Find(id);
            if (comp != null)
            {
                return PartialView("Details", comp);
            }
            return View("Index");
        }

        // Добавление
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product comp)
        {
            db.Products.Add(comp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Редактирование
        public ActionResult Edit(int id)
        {
            Product comp = db.Products.Find(id);
            if (comp != null)
            {
                return PartialView("Edit", comp);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product comp)
        {
            db.Entry(comp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Удаление
        public ActionResult Delete(int id)
        {
            Product comp = db.Products.Find(id);
            if (comp != null)
            {
                return PartialView("Delete", comp);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            Product comp = db.Products.Find(id);

            if (comp != null)
            {
                db.Products.Remove(comp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult AutocompleteSearch(string term)
        {
            var models = db.Products.Where(a => a.Name.Contains(term))
                            .Select(a => new { value = a.Name })
                            .Distinct();

            return Json(models, JsonRequestBehavior.AllowGet);
        }


    }
}

