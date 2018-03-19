using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeptIT.Models;

namespace DeptIT.Controllers
{
    public class HomeController : Controller
    {

        DBContext db = new DBContext();

        [HttpGet]
        public ActionResult Index()
        {
            var products = db.Products;
            ViewBag.Products = products;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            order.OrderDate = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + order.Client + ", за покупку!";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}