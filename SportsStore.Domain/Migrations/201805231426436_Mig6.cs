namespace SportsStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageData", c => c.Binary());
            AddColumn("dbo.Products", "ImageMimeType", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Products", "ImageMimeType");
            DropColumn("dbo.Products", "ImageData");
        }
    }
}
