namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicializaBanco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enderecoes", "LogradouroId", "dbo.Logradouroes");
            DropIndex("dbo.Enderecoes", new[] { "LogradouroId" });
            AddColumn("dbo.Enderecoes", "Endereco_EnderecoId", c => c.Int());
            AddColumn("dbo.Logradouroes", "EnderecoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Enderecoes", "Endereco_EnderecoId");
            CreateIndex("dbo.Logradouroes", "EnderecoId");
            AddForeignKey("dbo.Enderecoes", "Endereco_EnderecoId", "dbo.Enderecoes", "EnderecoId");
            AddForeignKey("dbo.Logradouroes", "EnderecoId", "dbo.Enderecoes", "EnderecoId", cascadeDelete: true);
            DropColumn("dbo.Enderecoes", "LogradouroId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enderecoes", "LogradouroId", c => c.Int());
            DropForeignKey("dbo.Logradouroes", "EnderecoId", "dbo.Enderecoes");
            DropForeignKey("dbo.Enderecoes", "Endereco_EnderecoId", "dbo.Enderecoes");
            DropIndex("dbo.Logradouroes", new[] { "EnderecoId" });
            DropIndex("dbo.Enderecoes", new[] { "Endereco_EnderecoId" });
            DropColumn("dbo.Logradouroes", "EnderecoId");
            DropColumn("dbo.Enderecoes", "Endereco_EnderecoId");
            CreateIndex("dbo.Enderecoes", "LogradouroId");
            AddForeignKey("dbo.Enderecoes", "LogradouroId", "dbo.Logradouroes", "LogradouroId");
        }
    }
}
