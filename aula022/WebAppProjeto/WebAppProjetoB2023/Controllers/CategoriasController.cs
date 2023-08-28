using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
//using WebAppProjetoB2023.Models;
using System.Net;
using System.Data.Entity;
using Modelo.Tabelas;
using Modelo.Cadastros;
using Servico.Cadastros;
using Servico.Tabelas;

namespace WebAppProjetoB2023.Controllers
{
    public class CategoriasController : Controller
    {

        //EFContext context = new EFContext();
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();
        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria c = categoriaServico.ObterCategoriaPorId((long)id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details(long? id)
        {
            
            return ObterVisaoCategoriaPorId(id);
        }
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria cat)
        {
            return GravarCategoria(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria cat)
        {
            
            return GravarCategoria(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Categoria c = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "O PRODUTO " + c.Nome.ToUpper() + " FOI REMOVIDO";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //metodos
        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }



    }
}