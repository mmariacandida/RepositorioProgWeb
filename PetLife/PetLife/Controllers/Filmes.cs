using AgendMoviesCRUD.Models;
using PetLife.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AgendMoviesCRUD.Controllers
{
    public class Filmes : Controller
    {
        private EFContext context;
        private object filme;
        private object filmes;

        public Filmes()
        {
            context = new EFContext();
        }

        public ActionResult HomeADM()
        {
            return View();
        }

        public ActionResult FilmesCadastrados()
        {
            return View();
        }

        public ActionResult ManterFilmes()
        {
            var pets = context.Filmes.ToList();
            return View(filmes);
        }

        private ActionResult View(object filmes)
        {
            throw new NotImplementedException();
        }

        public ActionResult CadastrarFilme()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarPet(Filme filme)
        {
            if (ModelState.IsValid)
            {
                context.Filmes.Add(filme);
                context.SaveChanges();
                return RedirectToAction("ManterFilmes");
            }

            return View("CadastrarFilme", filme);
        }

        public ActionResult EditarFilme(int id)
        {
            var pet = context.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }

            return View(pet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPet(Filme filme)
        {
            if (ModelState.IsValid)
            {
                context.Entry(filme).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("ManterFilmes");
            }

            return View(filme);
        }

        public ActionResult ExcluirFilme(int id)
        {
            var pet = context.Filmes.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }

            return View(filme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirFilmeConfirmed(int id)
        {
            var pet = context.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }

            context.Filmes.Remove(pet);
            context.SaveChanges();

            return RedirectToAction("ManterFilmes");
        }

        public ActionResult VisualizarFilme(int id)
        {
            var pet = context.Filmes.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }

            return View(filme);
        }

    }
}
