using AgendMoviesCRUD.Models;
using PetLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendMovies.Controllers
{
    public class InicioADMController : Controller
    {
        EFContext context = new EFContext();
       
        public ActionResult PagADM()
        {
            return View();
        }
       
        public ActionResult CadastrarFilme()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CadastrarFilme(Filme filme)
        {
            if (ModelState.IsValid)
            {
                context.Filmes.Add(filme);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        public ActionResult Lfilmes()
        {
            return View();
        }
    }
}
