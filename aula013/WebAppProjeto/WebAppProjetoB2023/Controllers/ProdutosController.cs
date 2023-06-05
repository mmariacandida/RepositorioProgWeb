using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Models;
using System.Data.Entity;
using System.Net;

namespace WebAppProjetoB2023.Controllers
{
    //MVC witch read/write ja cria o post com os http get e post
    //
    public class ProdutosController : Controller
    {
        EFContext context = new EFContext();
        public ActionResult Index()
        {
            var produtos = context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);
            //return View(context.Produtos.OrderBy(p => p.Nome));
            return View(produtos);
        }
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome");
            //ViewBag.chave_estrangeira = new SelectList(context.tabela.OrderBy(c => c.Nome), "chave", "mascara/nome_visivel");
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome");
            return View();
        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto p = context.Produtos.Find(id);
            if (p == null)
                return HttpNotFound();
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome", p.CategoriaId);
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome", p.FabricanteId);
            return View(p);
        }
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Produto p = context.Produtos.Where(pr => pr.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();
            if (p == null)
                HttpNotFound();
            return View(p);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Produto p = context.Produtos.Where(pr => pr.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();
            if (p == null)
                HttpNotFound();
            return View(p);
        }


        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(produto);
            }
        }
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            try
            {
               if (ModelState.IsValid)
                {
                    context.Entry(produto).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch
            {
                return View(produto);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Produto p = context.Produtos.Find(id);
                context.Produtos.Remove(p);
                context.SaveChanges();
                TempData["Message"] = "O PRODUTO " + p.Nome.ToUpper() + " FOI REMOVIDO";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
