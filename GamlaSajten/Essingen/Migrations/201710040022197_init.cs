namespace Essingen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaceCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Area = c.Int(nullable: false),
                        SignName = c.String(unicode: false),
                        CorporateName = c.String(unicode: false),
                        PlaceCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlaceCategories", t => t.PlaceCategoryId, cascadeDelete: true);

            Sql("CREATE index `IX_PlaceCategoryId` on `Places` (`PlaceCategoryId` DESC)");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "PlaceCategoryId", "dbo.PlaceCategories");
            DropIndex("dbo.Places", new[] { "PlaceCategoryId" });
            DropTable("dbo.Places");
            DropTable("dbo.PlaceCategories");
        }
    }
}
