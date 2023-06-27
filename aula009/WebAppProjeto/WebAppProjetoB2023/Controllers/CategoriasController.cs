using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Models;


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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria cat)
        {
            context.Categorias.Add(cat);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        

        
    }
}