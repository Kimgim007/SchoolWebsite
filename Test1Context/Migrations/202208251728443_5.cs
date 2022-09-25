namespace Test1Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamesLibraryDTO",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameDTO", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.UserDTO", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamesLibraryDTO", "UserId", "dbo.UserDTO");
            DropForeignKey("dbo.GamesLibraryDTO", "GameId", "dbo.GameDTO");
            DropIndex("dbo.GamesLibraryDTO", new[] { "GameId" });
            DropIndex("dbo.GamesLibraryDTO", new[] { "UserId" });
            DropTable("dbo.GamesLibraryDTO");
        }
    }
}
