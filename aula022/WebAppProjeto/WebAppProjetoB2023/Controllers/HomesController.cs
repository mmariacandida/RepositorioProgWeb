using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Models;
using Modelo.Tabelas;
using Modelo.Cadastros;
using Servico.Cadastros;
using Servico.Tabelas;

namespace WebAppProjetoB2023.Controllers
{
    public class HomesController : Controller
    {
     
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();

        public ActionResult Index()
        {
            Home h = new Home();
            h.Categorias = categoriaServico.ObterCategoriasClassificadasPorNome();
            h.Fabricantes = fabricanteServico.ObterFabricantesClassificadosPorNome();
            h.Produtos = produtoServico.ObterProdutosClassificadosPorNome();
            return View(h);
        }
        public ActionResult IndexComProdutosdoFabricante(long? id, bool tipo)
        {
            Home h = new Home();
            h.Categorias = categoriaServico.ObterCategoriasClassificadasPorNome();
            h.Fabricantes = fabricanteServico.ObterFabricantesClassificadosPorNome();
            if (id != null)
            {
                if (tipo)
                {
                    h.Produtos = produtoServico.ProdutosFabricante(long.Parse(id.ToString()));
                }
                else
                {
                    h.Produtos = produtoServico.ProdutosCategoria(long.Parse(id.ToString()));
                }
            }
            else
            {
                h.Produtos = produtoServico.ObterProdutosClassificadosPorNome();
            }
            return View(h);
        }
    }
}