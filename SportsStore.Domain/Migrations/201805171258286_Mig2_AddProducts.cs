namespace SportsStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig2_AddProducts : DbMigration
    {
        public override void Up()
        {
            using (var context = new Concrete.EFDbContext())
            {
                context.Products.Add(new Domain.Entities.Product { Name = "Football", Price = 125 });
                context.Products.Add(new Domain.Entities.Product { Name = "Surf board", Price = 1179 });
                context.Products.Add(new Domain.Entities.Product { Name = "Running shoes", Price = 195 });
                context.Products.Add(new Domain.Entities.Product { Name = "Test", Price = 11000 });
                context.SaveChanges();
            }
        }

        public override void Down()
        {
        }
    }
}
