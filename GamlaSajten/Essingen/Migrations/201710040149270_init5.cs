namespace Essingen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Streetaddress", c => c.String(unicode: false));
            DropColumn("dbo.Places", "Streetadress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Places", "Streetadress", c => c.String(unicode: false));
            DropColumn("dbo.Places", "Streetaddress");
        }
    }
}
