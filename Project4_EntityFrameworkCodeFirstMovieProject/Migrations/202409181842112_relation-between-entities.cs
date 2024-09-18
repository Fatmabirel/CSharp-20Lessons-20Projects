namespace Project4_EntityFrameworkCodeFirstMovieProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationbetweenentities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "CategoryId");
            AddForeignKey("dbo.Movies", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Category", c => c.String());
            DropForeignKey("dbo.Movies", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "CategoryId" });
            DropColumn("dbo.Movies", "CategoryId");
        }
    }
}
