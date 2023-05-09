using AppWeb2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb2023.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }

        public ActionResult Edit(long id)
        {
            return View(context.Categorias.Where(m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            context.Categorias.Remove(
            context.Categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            context.Categorias.Add(categoria);
            TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi alterado";
            return RedirectToAction("Index");
        }

        public ActionResult Details (long id)
        {
            return View(context.Categorias.Where(m => m.CategoriaId == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(context.Categorias.Where(m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Fabricantes.Remove(categoria);
            context.SaveChanges();
            TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi excluido";
            return RedirectToAction("Index");
        }

        // GET: Categorias
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
            categoria.CategoriaId = context.Categorias.Select(m => m.CategoriaId).Max() + 1;
            TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi registrado";
            return RedirectToAction("Index");
        }



    }
}