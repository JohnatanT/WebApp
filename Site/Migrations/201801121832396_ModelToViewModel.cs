namespace Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelToViewModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoas", "Cpf", c => c.String());
            AlterColumn("dbo.Pessoas", "Nome", c => c.String());
            AlterColumn("dbo.Pessoas", "SobreNome", c => c.String());
            AlterColumn("dbo.Pessoas", "Email", c => c.String());
            AlterColumn("dbo.Pessoas", "Telefone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoas", "Telefone", c => c.String(nullable: false));
            AlterColumn("dbo.Pessoas", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Pessoas", "SobreNome", c => c.String(maxLength: 20));
            AlterColumn("dbo.Pessoas", "Nome", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Pessoas", "Cpf", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
