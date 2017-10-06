namespace Repositorio.Migrations
{
    using Configuracao;
    using Model;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.PESSOA.AddOrUpdate(
                p => p.Nome,
                new Pessoa
                {
                    Nome = "Damilson",
                    Enderecos = new List<Endereco>() { new Endereco() {EnderecoNome = "Rua Idealista",Logradouro = new Logradouro() {Bairro = "Marechal Rondom",Cidade = "Caucaia",Estado = "Ceará",Numero = 604,Complemento = "Rua"}}},
                    Contatos = new List<Contato>() { new Contato() { Nome = "Fernando", TipoContato = Util.TipoContato.Celular, Agrupador = Util.Agrupador.trabalho },
                                                     new Contato() {Nome = "João",TipoContato = Util.TipoContato.Celular, Agrupador = Util.Agrupador.trabalho}}       
                }
            );
        }
    }
}
