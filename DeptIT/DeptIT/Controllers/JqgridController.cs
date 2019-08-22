using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeptIT.Models;
using Newtonsoft.Json;

namespace DeptIT.Controllers
{
    public class JqgridController : Controller
    {
        // GET: Jqgrid
        static DBContext db = new DBContext();
        static List<Product> products; // = db.Products.ToList(); 

        static JqgridController()
        {
            products = db.Products.ToList();
        }

        public ActionResult Index()
        {
            return View();
        }

        public string GetData()
        {
            return JsonConvert.SerializeObject(products);
        }
    }
}