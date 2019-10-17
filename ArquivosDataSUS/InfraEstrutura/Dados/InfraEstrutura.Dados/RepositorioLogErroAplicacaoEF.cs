using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class RepositorioLogErroAplicacaoEF : Repositorio<LogErroAplicacao>, IRepositorioLogErroAplicacao
    {
        public LogErroAplicacao GetbyID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<LogErroAplicacao> Buscar(LogErroAplicacao criterio)
        {
            throw new NotImplementedException();
        }
    }
}
