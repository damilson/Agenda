using Agenda.Model;
using System.Data.Entity;

namespace Agenda.Configuracao
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
        public DbSet<Logradouro> LOGRADOURO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}