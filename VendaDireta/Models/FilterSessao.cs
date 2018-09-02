using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VendaDireta.Models
{
    public class FilterSessao : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            dbContext db = new dbContext();
            var usuario = db.Usuario.FirstOrDefault(x => x.Email.ToLower() == HttpContext.Current.User.Identity.Name.ToLower());
            var controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
            bool bAcesso = false;

            if (controllerName == "login")
                bAcesso = true;
            if (controllerName == "cadastro")
                bAcesso = true;

            if (usuario != null)
            {
                filterContext.Controller.ViewBag.UsuarioId = usuario.UsuarioId;
                filterContext.Controller.ViewBag.Usuario = usuario.Email.ToLower();
                filterContext.Controller.ViewBag.UsuarioNome = usuario.Nome;
                filterContext.Controller.ViewBag.UsuarioReceita = usuario.Receita;
                bAcesso = true;
            }

            if (!bAcesso)
            {
                filterContext.Result = new RedirectToRouteResult(
    new RouteValueDictionary
    {
                            { "controller", "Login" },
                            { "action", "Login" }
    });
            }
        }

    }
}