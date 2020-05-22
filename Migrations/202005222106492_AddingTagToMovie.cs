namespace FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTagToMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VideoTags",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.TagId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.VideoTags", "MovieId", "dbo.Movies");
            DropIndex("dbo.VideoTags", new[] { "TagId" });
            DropIndex("dbo.VideoTags", new[] { "MovieId" });
            DropTable("dbo.VideoTags");
            DropTable("dbo.Tags");
        }
    }
}
