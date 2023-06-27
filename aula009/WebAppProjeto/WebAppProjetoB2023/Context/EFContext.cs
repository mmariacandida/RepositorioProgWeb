using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppProjetoB2023.Models
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { } // Contrutor que inicializa a classe, chama o metodo construtor da classe pai, que recebe a string de conexão
        public DbSet<Categoria> Categorias { get; set; } // faz uma tabela com base na classe Categoria
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
    }

}