using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class RepositorioLogErroArquivoEF : Repositorio<LogErroArquivo>, IRepositorioLogErroArquivo
    {

        public LogErroArquivo GetbyID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<LogErroArquivo> Buscar(LogErroArquivo criterio)
        {
            throw new NotImplementedException();
        }
    }
}
