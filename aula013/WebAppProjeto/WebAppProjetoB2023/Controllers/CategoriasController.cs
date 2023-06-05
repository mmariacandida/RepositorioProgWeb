using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Models;
using System.Net;
using System.Data.Entity;


namespace WebAppProjetoB2023.Controllers
{
    public class CategoriasController : Controller
    {

        EFContext context = new EFContext();
        
        // GET: Categorias
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria c = context.Categorias.Find(id);
            //acha a procura na tabela Categorias o id, e atribui essa categoria na variavel cc
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria c = context.Categorias.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }
        public ActionResult Edit(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria c = context.Categorias.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria cat)
        {
            context.Categorias.Add(cat);
            context.SaveChanges();
            TempData["Message"] = "A CATEGORIA " + cat.Nome.ToUpper() + " FOI ADICIONADA";
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria cat)
        {
            if (ModelState.IsValid)
            {
                context.Entry(cat).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria c = context.Categorias.Find(id);
            context.Categorias.Remove(c);
            context.SaveChanges();
            TempData["Message"] = "A CATEGORIA " + c.Nome.ToUpper() + " FOI DELETADA";
            return RedirectToAction("Index");
        }
        

        
    }
}