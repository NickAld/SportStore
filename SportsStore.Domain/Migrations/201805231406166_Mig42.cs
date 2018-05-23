namespace SportsStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig42 : DbMigration
    {
        public override void Up()
        {
            using (var context = new Concrete.EFDbContext())
            {
                context.Users.Add(new Entities.Users()
                {
                    UserName = "Admin",
                    UserPassword = "123456"
                });
                context.SaveChanges();
            }
        }
        
        public override void Down()
        {
        }
    }
}
