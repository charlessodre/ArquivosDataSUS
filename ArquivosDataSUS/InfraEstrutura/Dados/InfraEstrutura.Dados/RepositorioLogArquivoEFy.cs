﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class RepositorioLogArquivoEF : Repositorio<LogArquivo>, IRepositorioLogArquivo
    {

        public LogArquivo GetbyID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<LogArquivo> Buscar(LogArquivo criterio)
        {
            throw new NotImplementedException();
        }
    }
}
