namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicializaBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contatoes",
                c => new
                    {
                        ContatoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        TipoContato = c.Int(nullable: false),
                        Agrupador = c.Int(nullable: false),
                        Tipo = c.String(),
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContatoId)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.PessoaId);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        EnderecoNome = c.String(),
                        PessoaId = c.Int(nullable: false),
                        LogradouroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Logradouroes", t => t.LogradouroId, cascadeDelete: true)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.PessoaId)
                .Index(t => t.LogradouroId);

            CreateTable(
                "dbo.Logradouroes",
                c => new
                {
                    LogradouroId = c.Int(nullable: false, identity: true),
                    Numero = c.Int(nullable: false),
                    Complemento = c.String(),
                    Tipo = c.Int(nullable: false),
                    Bairro = c.String(),
                    Cidade = c.String(),
                    Estado = c.String(),
                    EnderecoId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.LogradouroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enderecoes", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.Enderecoes", "LogradouroId", "dbo.Logradouroes");
            DropForeignKey("dbo.Contatoes", "PessoaId", "dbo.Pessoas");
            DropIndex("dbo.Enderecoes", new[] { "LogradouroId" });
            DropIndex("dbo.Enderecoes", new[] { "PessoaId" });
            DropIndex("dbo.Contatoes", new[] { "PessoaId" });
            DropTable("dbo.Logradouroes");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Contatoes");
        }
    }
}
