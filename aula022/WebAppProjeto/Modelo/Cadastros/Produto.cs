using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Modelo.Tabelas;
namespace Modelo.Cadastros
{
    public class Produto
    {
            [DisplayName("Codigo")]
            public long? ProdutoId { get; set; }
            [StringLength(100, ErrorMessage = "O nome do produto precisa ter no mínimo 10 caracteres", MinimumLength = 10)]
            [Required(ErrorMessage = "Informe o nome do produto")]
            public string Nome { get; set; }
            [DisplayName("Data de Cadastro")]
            //[Required(ErrorMessage = "Informe a data de cadastro do produto")]
            public DateTime? DataCadastro { get; set; }
            [DisplayName("Categoria")]
            public long? CategoriaId { get; set; }
            [DisplayName("Fabricante")]
            public long? FabricanteId { get; set; }
            public Categoria Categoria { get; set; }
            public Fabricante Fabricante { get; set; }

        public string LogotipoMimeType { get; set; } //pega o tipo(png, jpg,mp4, html,css...) - MimeType são os tipos de arquivo que o navegador pode mostrar
        public byte[] Logotipo { get; set; }// Pega os bytes da imagem, pixeis, conteudo
        public string NomeArquivo { get; set; }
        public long TamanhoArquivo { get; set; }

    }
}