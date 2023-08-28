using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.Tabelas;
using Modelo.Cadastros;
namespace WebAppProjetoB2023.Models
{
    public class Home
    {
        public IQueryable<Categoria> Categorias;
        public IQueryable<Fabricante> Fabricantes;
        public IQueryable<Produto> Produtos;
      
    }
}