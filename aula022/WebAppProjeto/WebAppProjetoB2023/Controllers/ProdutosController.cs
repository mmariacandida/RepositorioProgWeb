using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebAppProjetoB2023.Models;
using System.Data.Entity;
using System.Net;
using System.IO;
using Modelo.Tabelas;
using Modelo.Cadastros;
using Servico.Cadastros;
using Servico.Tabelas;
namespace WebAppProjetoB2023.Controllers
{
    //MVC witch read/write ja cria o post com os http get e post
    //
    public class ProdutosController : Controller
    {
        //EFContext context = new EFContext();
        // private EFContext context = new EFContext(); // Acesso ao contexto (comentado)
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();
        private ActionResult ObterVisaoProdutoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = produtoServico.ObterProdutoPorId((long)id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        private void PopularViewBag(Produto produto = null)
        {
            if (produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(),
                "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadosPorNome(),
                "FabricanteId", "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(),
                "CategoriaId", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadosPorNome(),
                "FabricanteId", "Nome", produto.FabricanteId);
            }
        }
        // GET: Produtos
        public ActionResult Index()
        {
            //var produtos = context.Produtos.Include(c => c.Categoria). // Acesso ao contexto
            // Include(f => f.Fabricante).OrderBy(n => n.Nome); // (comentado)
            //return View(produtos);
            return View(produtoServico.ObterProdutosClassificadosPorNome());
        }
        //public ActionResult Index()
        //{
        //    var produtos = context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);
        //    //return View(context.Produtos.OrderBy(p => p.Nome));
        //    return View(produtos);
        //}
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }
        public ActionResult Edit(long? id)
        {
            PopularViewBag(produtoServico.ObterProdutoPorId((long)id));
            return ObterVisaoProdutoPorId(id);
        }
        public ActionResult Details(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }
        public ActionResult Delete(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }



        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            return GravarProduto(produto);
        }

        [HttpPost]
        public ActionResult Edit(Produto produto,
HttpPostedFileBase logotipo = null, string chkRemoverImagem = null)
        {
            return GravarProduto(produto, logotipo, chkRemoverImagem);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Produto produto = produtoServico.EliminarProdutoPorId(id);
                TempData["Message"] = "O PRODUTO " + produto.Nome.ToUpper() + " FOI REMOVIDO";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Metodos

        private ActionResult GravarProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch
            {
                return View(produto);
            }
        }

        private byte[] SetLogotipo(HttpPostedFileBase logotipo)
        {
            var bytesLogotipo = new byte[logotipo.ContentLength];//reservou espaço para os conteudos do byte(arquivo)
            logotipo.InputStream.Read(bytesLogotipo, 0 , logotipo.ContentLength);//pega o conteudo
            return bytesLogotipo;

        }

        public FileContentResult GetLogotipo(long id)//retorna a imagem, do BD
        {
            Produto produto = produtoServico.ObterProdutoPorId(id);
            if (produto != null)
            {
                return File(produto.Logotipo, produto.LogotipoMimeType);
            }
            return null;
        }
        public FileContentResult GetLogotipo2(long id)//retira do servidor
        {
            Produto produto = produtoServico.ObterProdutoPorId(id);
            if (produto != null)
            {
                if (produto.NomeArquivo != null)
                {
                    var bytesLogotipo = new byte[produto.TamanhoArquivo];
                    FileStream fileStream = new
                    FileStream(Server.MapPath("~/App_Data/" + produto.NomeArquivo), FileMode.Open,
                    FileAccess.Read);
                    fileStream.Read(bytesLogotipo, 0, (int)produto.TamanhoArquivo);
                    return File(bytesLogotipo, produto.LogotipoMimeType);
                }
            }
            return null;
        }
        public ActionResult DownloadArquivo(long id)//salvar localmente, retira do bd
        {
            try
            {
                Produto produto = produtoServico.ObterProdutoPorId(id);
                FileStream fileStream = new FileStream(Server.MapPath(
                "~/App_Data/" + produto.NomeArquivo), FileMode.Create, FileAccess.Write);//cria um arquivo na pasta padrao
                fileStream.Write(produto.Logotipo, 0, Convert.ToInt32(produto.TamanhoArquivo));
                fileStream.Close();
                return File(fileStream.Name, produto.LogotipoMimeType, produto.NomeArquivo);
            }
            catch
            {
                return RedirectToAction("Edit/" + id.ToString());
            }
            
        }
        public ActionResult DownloadArquivo2(long id)//salvar localmente, retira do servidor
        {
            Produto produto = produtoServico.ObterProdutoPorId(id);
            FileStream fileStream = new FileStream(Server.MapPath("~/App_Data/" + produto.NomeArquivo), FileMode.Open, FileAccess.Read);
            return File(fileStream.Name, produto.LogotipoMimeType, produto.NomeArquivo);
        }
        
        
        private ActionResult GravarProduto(Produto produto, HttpPostedFileBase logotipo, string chkRemoverImagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (chkRemoverImagem != null)
                    {
                        produto.Logotipo = null;
                    }
                    if (logotipo != null)
                    {
                        produto.LogotipoMimeType = logotipo.ContentType;
                        produto.Logotipo = SetLogotipo(logotipo);
                        produto.NomeArquivo = logotipo.FileName;
                        produto.TamanhoArquivo =logotipo.ContentLength;
                        //salva no BD


                        string strFileName = Server.MapPath("~/App_Data/") + Path.GetFileName(logotipo.FileName);
                        logotipo.SaveAs(strFileName);
                        //salva no local

                        //se os dis tiverem aqui o arquivo duplica
                    }
                    GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                PopularViewBag(produto);
                return View(produto);
            }
            catch
            {
                PopularViewBag(produto);
                return View(produto);
            }
        }

        //Termina aqui
    }
}
