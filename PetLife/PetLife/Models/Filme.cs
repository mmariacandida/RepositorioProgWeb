using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendMoviesCRUD.Models
{
    public class Filme
    {
        public long FilmeId { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int Duracao { get; set; }
        public string Classificacao { get; set; }
        public string Genero { get; set; }
    }
}