using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VendaDireta.Models;

namespace VendaDireta.Controllers
{
    public class HomeController : Controller
    {
        private dbContext db = new dbContext();

        public ActionResult Index()
        {
            var produto = db.Produto.Include(p => p.Usuario).Where(p => p.Vendido == false);
            return View(produto.ToList());
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