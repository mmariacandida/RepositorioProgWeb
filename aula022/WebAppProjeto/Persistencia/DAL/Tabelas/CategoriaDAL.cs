﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Tabelas;
using Persistencia.Context;
namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return context.Categorias.OrderBy(b => b.Nome);
        }
       
        public Categoria ObterCategoriaPorId(long id)
        {
            if (id == 0)
                return context.Categorias.Find(id);
            else
                return context.Categorias.Where(f => f.CategoriaId == id).Include("Produtos.Fabricante").First();
   
        }
        public void GravarCategoria(Categoria categoria)
        {
            Categoria c = ObterCategoriaPorId(categoria.CategoriaId);
            if (c == null)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Categoria EliminarCategoriaPorId(long id)
        {
            Categoria c = ObterCategoriaPorId(id);
            context.Categorias.Remove(c);
            context.SaveChanges();
            return c;
        }
    }
}
