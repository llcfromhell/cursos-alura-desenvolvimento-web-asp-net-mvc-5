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
            ViewBag.Produto = new Produto();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {

            if (1 == produto.CategoriaId && produto.Preco < 100.00)
            {
                ModelState.AddModelError("produto.Preco", "Para produtos de Informática o preço deve ser maior que 100.00");
            } 

            if (ModelState.IsValid)
            {
                new ProdutosDAO().Adiciona(produto);
            }
            else
            {
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.Lista();

                ViewBag.Produto = produto;
                return View("Form");
            }
            return RedirectToAction("IndexViewBag");
        }

        public ActionResult IndexViewBag()
        {

            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();

            return View(produtos);
        }

        public ActionResult Visualiza(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            ViewBag.Produto = produto;
            return View(produto);
        }
    }
}