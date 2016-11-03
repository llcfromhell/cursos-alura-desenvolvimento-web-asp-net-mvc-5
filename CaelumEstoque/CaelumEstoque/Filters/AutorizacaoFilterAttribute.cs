using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaelumEstoque.Filters
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usuarioLogado = filterContext.HttpContext.Session["usuarioLogado"] != null;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if ("Login" == controllerName && usuarioLogado)
            {
                filterContext.Result = new RedirectResult("/");
            } 

            if (!usuarioLogado && "Login" != controllerName)
            {

                filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary(
                               new { action = "Index", controller = "Login" }));
            }

        }

    }
}