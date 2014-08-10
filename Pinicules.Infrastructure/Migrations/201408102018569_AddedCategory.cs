namespace Pinicules.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        IdMovie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.MovieCategories",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Category_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Category_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.MovieCategories", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MovieCategories", new[] { "Category_Id" });
            DropIndex("dbo.MovieCategories", new[] { "Movie_Id" });
            DropTable("dbo.MovieCategories");
            DropTable("dbo.Categories");
        }
    }
}
