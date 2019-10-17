using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;

namespace Application
{
    public class EstadoUFApplication : ApplicationBase<EstadoUF, Int32>
    {
        public IRepositorioEstadoUF repositorioEstadoUF { get; set; }
        public EstadoUFApplication() 
        {
            this.repositorio = repositorioEstadoUF;
        }
        
    }
}
