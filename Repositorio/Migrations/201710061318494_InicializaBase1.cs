namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicializaBase1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Logradouroes", "EnderecoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logradouroes", "EnderecoId", c => c.Int(nullable: false));
        }
    }
}
