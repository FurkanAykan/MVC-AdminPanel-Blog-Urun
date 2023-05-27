namespace EntityLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _map : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Map", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Map", c => c.String(maxLength: 255));
        }
    }
}
