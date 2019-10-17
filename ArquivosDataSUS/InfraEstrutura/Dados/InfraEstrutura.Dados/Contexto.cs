using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Domain.Entity;

    public partial class ArquivoDataSUSEntities : DbContext
    {
        public ArquivoDataSUSEntities()
            : base("name=DB_ARQUIVOS_DATASUSEntities")
        {
            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Arquivo> Arquivo { get; set; }
        public DbSet<EstadoUF> EstadoUF { get; set; }  
        public DbSet<TipoArquivo> TipoArquivo { get; set; }  
        public DbSet<Usuario> Usuario { get; set; }


    }
}
