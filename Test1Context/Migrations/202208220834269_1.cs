namespace Test1Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameDTOes", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.UserDTOGameDTOes",
                c => new
                    {
                        UserDTO_Id = c.Int(nullable: false),
                        GameDTO_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserDTO_Id, t.GameDTO_Id })
                .ForeignKey("dbo.UserDTOes", t => t.UserDTO_Id, cascadeDelete: true)
                .ForeignKey("dbo.GameDTOes", t => t.GameDTO_Id, cascadeDelete: true)
                .Index(t => t.UserDTO_Id)
                .Index(t => t.GameDTO_Id);
            
            CreateTable(
                "dbo.TeamDTOUserDTOes",
                c => new
                    {
                        TeamDTO_Id = c.Int(nullable: false),
                        UserDTO_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamDTO_Id, t.UserDTO_Id })
                .ForeignKey("dbo.TeamDTOes", t => t.TeamDTO_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserDTOes", t => t.UserDTO_Id, cascadeDelete: true)
                .Index(t => t.TeamDTO_Id)
                .Index(t => t.UserDTO_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamDTOUserDTOes", "UserDTO_Id", "dbo.UserDTOes");
            DropForeignKey("dbo.TeamDTOUserDTOes", "TeamDTO_Id", "dbo.TeamDTOes");
            DropForeignKey("dbo.TeamDTOes", "GameId", "dbo.GameDTOes");
            DropForeignKey("dbo.UserDTOGameDTOes", "GameDTO_Id", "dbo.GameDTOes");
            DropForeignKey("dbo.UserDTOGameDTOes", "UserDTO_Id", "dbo.UserDTOes");
            DropIndex("dbo.TeamDTOUserDTOes", new[] { "UserDTO_Id" });
            DropIndex("dbo.TeamDTOUserDTOes", new[] { "TeamDTO_Id" });
            DropIndex("dbo.UserDTOGameDTOes", new[] { "GameDTO_Id" });
            DropIndex("dbo.UserDTOGameDTOes", new[] { "UserDTO_Id" });
            DropIndex("dbo.TeamDTOes", new[] { "GameId" });
            DropTable("dbo.TeamDTOUserDTOes");
            DropTable("dbo.UserDTOGameDTOes");
            DropTable("dbo.TeamDTOes");
            DropTable("dbo.UserDTOes");
            DropTable("dbo.GameDTOes");
        }
    }
}
