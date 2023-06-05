using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Models;

namespace WebAppProjetoB2023.Controllers
{
    public class HomesController : Controller
    {
        EFContext context = new EFContext();
        // GET: Homes
        public ActionResult Index()
        {
            Home h = new Home();
            h.Categorias = context.Categorias.OrderBy(c => c.Nome);
            h.Fabricantes = context.Fabricantes.OrderBy(c => c.Nome);
            h.Produtos = context.Produtos.OrderBy(p => p.Nome);
            return View(h);
        }
    }
}