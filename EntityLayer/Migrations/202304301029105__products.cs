namespace EntityLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _products : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ThumbUrl", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ThumbUrl");
        }
    }
}
