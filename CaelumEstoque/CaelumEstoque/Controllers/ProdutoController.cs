using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {

            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();

            return View(produtos);
        }

        public ActionResult Form()
        {

            ViewBag.categorias = new CategoriasDAO().Lista();

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            new ProdutosDAO().Adiciona(produto);

            return RedirectToAction("IndexViewBag");
        }

        public ActionResult IndexViewBag()
        {

            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();

            ViewBag.produtos = produtos;

            return View();
        }
    }
}