using Repositorio.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repositorio.Configuracao
{
    public class Context : DbContext
    {
        public Context()
            : base("Agenda") 
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Pessoa> PESSOA { get; set; }
        public DbSet<Contato> CONTATO { get; set; }
        public DbSet<Endereco> ENDERECO { get; set; }
        public DbSet<Logradouro> LOGRADOUROs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
