using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Cadastros;
using Persistencia.Context;
namespace Persistencia.DAL.Cadastros
{
    public class ProdutoDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Produto> ObterProdutosClassificadosPorNome()
        {
            return context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).
            OrderBy(n => n.Nome);
        }
        public Produto ObterProdutoPorId(long id)
        {
            return context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).
            Include(f => f.Fabricante).First();
        }
        public void GravarProduto(Produto produto)
        {
            if (produto.ProdutoId == null)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                context.Entry(produto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Produto EliminarProdutoPorId(long id)
        {
            Produto produto = ObterProdutoPorId(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return produto;
        }
        public IQueryable<Produto> ProdutosFabricante(long id)
        {
            return context.Produtos.Where(p => p.FabricanteId == id);
        }
        public IQueryable<Produto> ProdutosCategoria(long id)
        {
            return context.Produtos.Where(p => p.CategoriaId == id);
        }
    }
}
