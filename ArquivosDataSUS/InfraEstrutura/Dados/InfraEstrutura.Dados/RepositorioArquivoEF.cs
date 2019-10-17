using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class RepositorioArquivoEF : Repositorio<Arquivo>, IRepositorioArquivo
    {


        public Arquivo GetbyID(string id)
        {
            throw new NotImplementedException();
            //using (ArquivoDataSUSEntities context = new ArquivoDataSUSEntities())
            //{
            //    return context.Arquivo.Where(x => x.Id == id).FirstOrDefault();
            //}
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Arquivo GetByName(string nome)
        {
            using (ArquivoDataSUSEntities context = new ArquivoDataSUSEntities())
            {
                return context.Arquivo.Where(x => x.Nome.ToUpper() == nome.ToUpper()).FirstOrDefault();
            }
        }

        public List<Arquivo> Buscar(Arquivo criterio)
        {
            using (ArquivoDataSUSEntities context = new ArquivoDataSUSEntities())
            {

                var query = context.Arquivo.Where(x => x.IdTipoArquivo == criterio.IdTipoArquivo || x.IdEstadoUF == criterio.IdEstadoUF).OrderBy(x => x.Nome);
                return query.ToList();

            }
        }


        List<Arquivo> IRepositorioArquivo.GetByUF(string uf)
        {
            using (ArquivoDataSUSEntities context = new ArquivoDataSUSEntities())
            {
                return context.Arquivo.Where(x => x.EstadoUF.Sigla.ToUpper() == uf.ToUpper()).ToList();
            }
        }


        public List<Arquivo> GetByUFeTipoArquivo(string uf, string tipoArquivo)
        {

            using (ArquivoDataSUSEntities context = new ArquivoDataSUSEntities())
            {
                return context.Arquivo.Where(x => x.EstadoUF.Sigla.ToUpper() == uf.ToUpper() && x.TipoArquivo.Nome.ToUpper() == tipoArquivo.ToUpper()).ToList();
            }
        }
    }
}
