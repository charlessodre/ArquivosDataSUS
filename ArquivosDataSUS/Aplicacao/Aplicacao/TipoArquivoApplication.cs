using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;

namespace Application
{
    public class TipoArquivoApplication : ApplicationBase<TipoArquivo , Int32>
    {
        public IRepositorioTipoArquivo repositorioTipoArquivo { get; set; }
        public TipoArquivoApplication() 
        {
            this.repositorio = repositorioTipoArquivo;
        }
        
    }
}
