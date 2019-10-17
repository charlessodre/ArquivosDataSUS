using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;

namespace Application
{
    public class ArquivoApplication : ApplicationBase<Arquivo, string>
    {
        public IRepositorioArquivo repositorioArquivo { get; set; }
        public ArquivoApplication() 
        {
            this.repositorio = repositorioArquivo;
        }
        
    }
}
