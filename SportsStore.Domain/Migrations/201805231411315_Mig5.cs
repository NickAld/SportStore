namespace SportsStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Accsess", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Accsess");
        }
    }
}
