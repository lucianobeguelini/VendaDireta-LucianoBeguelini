using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VendaDireta.Models;

namespace VendaDireta.Controllers
{
    public class LoginController : Controller
    {
        private dbContext db = new dbContext();

        // GET: Login
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection frmLogin)
        {
            var result = false;
            var password = frmLogin["txtSenha"];
            var userName = frmLogin["txtUsuario"].ToUpper();
            var o = from c in db.Usuario
                    where c.Email == userName && c.Senha == password
                    select c;

            if (o.ToList().Count > 0)
                result = true;

            if (result)
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login ou senha inválidos!");
                TempData["Mensagem"] = "Login ou senha inválidos!";
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "UsuarioId,Nome,Email,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(usuario);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}