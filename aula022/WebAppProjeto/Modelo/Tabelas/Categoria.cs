using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.Cadastros;
namespace Modelo.Tabelas
{
    public class Categoria
    {
        public long CategoriaId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        //I relaciona ao conceito de interface. Assinatura nome e paremetros de um metodo
    }
}