namespace SportsStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Category", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
        }
    }
}
