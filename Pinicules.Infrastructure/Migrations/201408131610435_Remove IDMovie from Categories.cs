namespace Pinicules.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIDMoviefromCategories : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "IdMovie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "IdMovie", c => c.Int(nullable: false));
        }
    }
}
