using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class RepositorioEstadoUFEF : Repositorio<EstadoUF>, IRepositorioEstadoUF
    {

        EstadoUF IRepositorioEstadoUF.FindByUF(string uf)
        {
            using (ArquivoDataSUSEntities context = new ArquivoDataSUSEntities())
            {
                return context.EstadoUF.Where(x => x.Sigla.ToUpper() == uf.ToUpper()).FirstOrDefault();
            }
        }

       
        EstadoUF IRepositorioEstadoUF.FindByName(string nome)
        {
            using (ArquivoDataSUSEntities context = new ArquivoDataSUSEntities())
            {
                return context.EstadoUF.Where(x => x.Nome.ToUpper() == nome.ToUpper()).FirstOrDefault();
            }
        }


        public EstadoUF GetbyID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<EstadoUF> Buscar(EstadoUF criterio)
        {
            throw new NotImplementedException();
        }


        public bool Insert(EstadoUF item)
        {
            throw new NotImplementedException();
        }


    }
}
