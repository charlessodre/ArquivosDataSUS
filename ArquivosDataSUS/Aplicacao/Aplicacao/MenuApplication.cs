using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;

namespace Application
{
    public class MenuApplication : ApplicationBase<ModuloMenu,int>
    {
        public IServiceMenu serviceMenu { get; set; }
        public List<ModuloMenu> ObtemMenus() 
        {
            return serviceMenu.ObtemMenus();
        }
    }
}
