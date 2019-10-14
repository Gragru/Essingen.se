namespace Essingen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Places", "Latitude", c => c.Decimal(nullable: false, precision: 16, scale: 6));
            AlterColumn("dbo.Places", "Longitude", c => c.Decimal(nullable: false, precision: 16, scale: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Places", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
