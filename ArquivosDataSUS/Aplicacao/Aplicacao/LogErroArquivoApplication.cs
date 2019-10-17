using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;

namespace Application
{
    public class LogErroArquivoApplication : ApplicationBase<LogErroArquivo, Int32>
    {
        public IRepositorioLogErroArquivo repositorioLogErroArquivo { get; set; }
        public LogErroArquivoApplication() 
        {
            this.repositorio = repositorioLogErroArquivo;
        }
        
    }
}
