using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface IRepositorioEstadoUF : IRepositorio<EstadoUF, Int32>
    {
        EstadoUF FindByName(string nome);
        EstadoUF FindByUF(string uf);
    }
}
