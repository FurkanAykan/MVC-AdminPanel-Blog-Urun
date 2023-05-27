namespace EntityLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _pagecategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PageCategories", "CategoryName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ProductCategories", "CategoryName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategories", "CategoryName", c => c.String(maxLength: 100));
            AlterColumn("dbo.PageCategories", "CategoryName", c => c.String(maxLength: 100));
        }
    }
}
