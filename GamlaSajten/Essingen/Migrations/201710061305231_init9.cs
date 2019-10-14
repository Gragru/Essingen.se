namespace Essingen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "MainImage", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "MainImage");
        }
    }
}
