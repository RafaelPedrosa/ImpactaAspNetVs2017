using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer
{
    //DbContexct = Heraãnça do EntityFramework
    //Quando adiciona uma referência os projetos da pasta conseguem visualizar conexões ou conexões do proj
    public class ViagensOnlineDbContext : DbContext 
    {
        public ViagensOnlineDbContext() : base("viagensOnlineConnectionString")
        {

        }

        public DbSet <Destino> Destinos{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
