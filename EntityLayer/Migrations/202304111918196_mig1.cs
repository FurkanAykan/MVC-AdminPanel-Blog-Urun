namespace EntityLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Adress = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 14),
                        Email = c.String(maxLength: 50),
                        Whatsapp = c.String(maxLength: 14),
                        Map = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.PageCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 100),
                        ImageUrl = c.String(maxLength: 255),
                        MetaDescription = c.String(maxLength: 255),
                        MetaKey = c.String(maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        PageTitle = c.String(maxLength: 255),
                        ImageUrl = c.String(maxLength: 255),
                        Thumbrl = c.String(maxLength: 255),
                        MetaDescription = c.String(maxLength: 255),
                        MetaKey = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        PageDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PageID)
                .ForeignKey("dbo.PageCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 100),
                        ImageUrl = c.String(maxLength: 255),
                        ThumbUrl = c.String(maxLength: 255),
                        MetaDescription = c.String(maxLength: 255),
                        MetaKey = c.String(maxLength: 255),
                        IsAvtive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 100),
                        ImageUrl = c.String(maxLength: 255),
                        MetaDescription = c.String(maxLength: 255),
                        MetaKey = c.String(maxLength: 255),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ProductDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(maxLength: 255),
                        ThumbUrl = c.String(maxLength: 255),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Socials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Facebook = c.String(maxLength: 255),
                        Instagram = c.String(maxLength: 255),
                        Twitter = c.String(maxLength: 255),
                        Youtube = c.String(maxLength: 255),
                        Linkedin = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Password = c.String(maxLength: 20),
                        Roles = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImages", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.Pages", "CategoryID", "dbo.PageCategories");
            DropIndex("dbo.ProductImages", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Pages", new[] { "CategoryID" });
            DropTable("dbo.Users");
            DropTable("dbo.Socials");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Pages");
            DropTable("dbo.PageCategories");
            DropTable("dbo.Contacts");
        }
    }
}
