using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;

namespace Application
{
    public class LogArquivoApplication : ApplicationBase<LogArquivo, int>
    {
        public IRepositorioLogArquivo repositorioLogArquivo { get; set; }
        public LogArquivoApplication() 
        {
            this.repositorio = repositorioLogArquivo;
        }
        
    }
}
