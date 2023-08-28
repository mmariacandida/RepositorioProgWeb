﻿using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
    public class FabricanteServico
    {
       
            private FabricanteDAL fabricanteDAL = new FabricanteDAL();
            public IQueryable<Fabricante> ObterFabricantesClassificadosPorNome()
            {
                return fabricanteDAL.ObterFabricantesClassificadosPorNome();
            }
            public Fabricante ObterFabricantePorId(long id)
            {
                return fabricanteDAL.ObterFabricantePorId(id);
            }
            public void GravarFabricante(Fabricante fabri)
            {
                fabricanteDAL.GravarFabricante(fabri);
            }
            public Fabricante EliminarFabricantePorId(long id)
            {
                return fabricanteDAL.EliminarFabricantePorId(id);
            }
    }
}
