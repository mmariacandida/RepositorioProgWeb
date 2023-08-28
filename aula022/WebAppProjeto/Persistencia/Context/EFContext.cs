using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Modelo.Tabelas;
using Modelo.Cadastros;
using System.Data.Entity.ModelConfiguration.Conventions;
using Persistencia.Migrations;

namespace Persistencia.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") // Contrutor que inicializa a classe, chama o metodo construtor da classe pai, que recebe a string de conexão
            // "base" referencia o metodo contrutor da classe pai(dbcontext)
        {
            Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
            //Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>()); //construtor que apaga e recria se o modelo mudou        
        } 
        public DbSet<Categoria> Categorias { get; set; } // faz uma tabela com base na classe Categoria
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }//deixa singular o nome da tabela no BD
    }
}