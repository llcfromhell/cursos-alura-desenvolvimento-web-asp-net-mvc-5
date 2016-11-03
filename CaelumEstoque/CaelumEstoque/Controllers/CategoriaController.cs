using CaelumEstoque.DAO;
using CaelumEstoque.Filters;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            ViewBag.categorias = new CategoriasDAO().Lista();

            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(CategoriaDoProduto categoria)
        {
            new CategoriasDAO().Adiciona(categoria);

            return RedirectToAction("Index");
        }
    }
}