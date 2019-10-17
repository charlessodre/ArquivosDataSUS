using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface IRepositorioArquivo : IRepositorio<Arquivo, string>
    {
        Arquivo GetByName(string nome);
        List<Arquivo> GetByUF(string uf);
        List<Arquivo> GetByUFeTipoArquivo(string uf, string tipoArquivo);

    }
}
