using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class RepositorioTipoArquivoEF : Repositorio<TipoArquivo>, IRepositorioTipoArquivo
    {
        TipoArquivo IRepositorioTipoArquivo.FindByName(string nome)
        {
            using (ArquivoDataSUSEntities context = new ArquivoDataSUSEntities())
            {
                return context.TipoArquivo.Where(x => x.Nome.ToUpper() == nome.ToUpper()).FirstOrDefault();
            }
        }

        public TipoArquivo GetbyID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoArquivo> Buscar(TipoArquivo criterio)
        {
            throw new NotImplementedException();
        }
    }
}
