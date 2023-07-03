using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AgendMoviesCRUD.Models;

namespace AgendMoviesCRUD.Models
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>().HasKey(f => f.FilmeId);
            // outras configurações...
        }

        public DbSet<Filme> Filmes { get; set; }
    }
}