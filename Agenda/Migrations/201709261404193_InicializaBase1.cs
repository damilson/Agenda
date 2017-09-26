namespace Agenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicializaBase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enderecoes", "EnderecoNome", c => c.String());
            DropColumn("dbo.Logradouroes", "Rua");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logradouroes", "Rua", c => c.String());
            DropColumn("dbo.Enderecoes", "EnderecoNome");
        }
    }
}
