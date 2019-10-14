namespace Essingen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Places", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Places", "Streetadress", c => c.String(unicode: false));
            AddColumn("dbo.Places", "ZipCode", c => c.String(unicode: false));
            AddColumn("dbo.Places", "Phone", c => c.String(unicode: false));
            AddColumn("dbo.Places", "Email", c => c.String(unicode: false));
            AddColumn("dbo.Places", "Url", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "Url");
            DropColumn("dbo.Places", "Email");
            DropColumn("dbo.Places", "Phone");
            DropColumn("dbo.Places", "ZipCode");
            DropColumn("dbo.Places", "Streetadress");
            DropColumn("dbo.Places", "Longitude");
            DropColumn("dbo.Places", "Latitude");
        }
    }
}
