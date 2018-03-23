using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeptIT.Models;
using DeptIT.Utils;

namespace DeptIT.Controllers
{
    public class HomeController : Controller
    {

        DBContext db = new DBContext();
        public int Orders_cnt = 0;

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Product> products = db.Products;
            string client = "";
            try
            {
                client = HttpContext.Request.Cookies["client"].Value;
            }
            catch
            { }

            Session["login"] = "salex42";
            ViewBag.Products = products;
            ViewBag.Client = client;
            ViewData["cnt"] = Orders_cnt;
            return View();
        }


        [HttpGet]
        public ActionResult Products()
        {
            return View(db.Products);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Ordert order)
        {
            //order.OrderDate = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            HttpContext.Response.Cookies["client"].Value = order.Client;
            db.Orders.Add(order);
            Orders_cnt++;
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + order.Client + ", за покупку!";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return new HttpStatusCodeResult(404);

            return View();
        }

        [HttpGet]
        public HtmlResult Square(int a = 2, int b = 4)
        {
            double square;
            square = a * b / (double)2;
            return new HtmlResult(String.Format("<h2> Площадь треугольника: {0:0.###} </h2>", square));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public FileResult GetFile()
        {
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/1EM.pdf");
            // Тип файла - content-type
            string file_type = "application/pdf";
            // Имя файла - необязательно
            string file_name = "1EM.pdf";
            return File(file_path, file_type, file_name);
        }

        public string Context()
        {
            HttpContext.Response.Write("<h1>Hello World</h1>");
            HttpContext.Response.Write("<h1>Hello World, login " + Session["login"] + "</h1>");
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
                "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
        }


        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchProduct(string name)
        {
            var allproducts = db.Products.Where(a => a.Name.Contains(name)).ToList();
            if (allproducts.Count <= 0)
            {
                return PartialView();
            }
            return PartialView(allproducts);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Product prod = db.Products.FirstOrDefault(a => a.Id == id);
            if (prod != null)
            {
                return PartialView(prod);
            }
            return HttpNotFound();
        }
    }
}