namespace EntityLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _initq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "Description", c => c.String(maxLength: 255));
        }
    }
}
